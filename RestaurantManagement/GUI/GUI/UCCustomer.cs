using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using BLL;

namespace GUI
{
    public partial class UCCustomer : UserControl
    {
        Form_Restaurant mainform;
        DataGridView data;
        public CustomerBLL customerBLL;

        public UCCustomer(Form_Restaurant form)
        {
            customerBLL = new CustomerBLL();
            mainform = form;
            InitializeComponent();
            loadData();
            dataGridViewListCustomer.ReadOnly = true;
            dataGridViewListCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
            this.dataGridViewListCustomer.Columns["ID"].Visible = false;
        }

        int pageNumber = 1;
        int numberRecord = 15;
        public DataGridView GetDataGridView()
        {
            return data;
        }

        public void loadData()
        {
            dataGridViewListCustomer.AutoGenerateColumns = false;
            List<Customer> lstCustomer = customerBLL.GetListCustomer();
            dataGridViewListCustomer.DataSource = lstCustomer;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CustomerID";
            column.Name = "ID";
            column.Visible = false;
            dataGridViewListCustomer.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Name";
            column.Visible = true;
            dataGridViewListCustomer.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "IsFemale";
            column.Name = "Gender";

            dataGridViewListCustomer.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "PhoneNumber";
            column.Name = "Phone";
            dataGridViewListCustomer.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CMND";
            column.Name = "CMND";
            dataGridViewListCustomer.Columns.Add(column);

        }

        private void dataGridViewListCustomer_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = 20;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pageNumber - 1 > 0)
            {
                pageNumber--;
                dataGridViewListCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalRecord = 0;
            using (RestaurantContextEntities db = new RestaurantContextEntities())
            {
                totalRecord = db.Employees.Count();
            }
            if (pageNumber - 1 < totalRecord / numberRecord)
            {
                pageNumber++;
                dataGridViewListCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);

            }
        }

        private void dataGridViewListCustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridViewListCustomer.Columns[e.ColumnIndex].Name == "Gender")
            {
                if (e.Value != null)
                {
                    int gender = Convert.ToInt32(e.Value);
                    if (gender == 1)
                    {
                        e.Value = "Female";
                    }
                    else
                    {
                        e.Value = "Male";
                    }
                    e.FormattingApplied = true;
                }
            }
        }

        private void rB1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search..." || txtSearch.Text == "")
            {
                dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 1, pageNumber,numberRecord);
            }
            else
            {
                dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 3, pageNumber, numberRecord);
            }
            if (dataGridViewListCustomer.RowCount <= numberRecord)
            {
                btnPrevious.Visible = false;
                btnNext.Visible = false;
            }
        }

        private void rB2_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search..." || txtSearch.Text == "")
            {
                dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 2, pageNumber, numberRecord);
            }
            else
            {
                dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 4, pageNumber, numberRecord);
            }
            if (dataGridViewListCustomer.RowCount <= numberRecord)
            {
                btnPrevious.Visible = false;
                btnNext.Visible = false;
            }
        }

        private void btnDeletetxt_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            dataGridViewListCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //0: cac loai ko can phan loai,1-3:nam,2-4:nu
            if(txtSearch.Text!="")
            {
                dataGridViewListCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
            }
            if (rB1.Checked == false && rB2.Checked == false)
            {

                dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 0, pageNumber, numberRecord);
            }
            if (txtSearch.Text != "")
            {
                if (rB1.Checked == true)
                    dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 3, pageNumber, numberRecord);
                if (rB2.Checked == true)
                    dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 4, pageNumber, numberRecord);
            }
            else
            {
                if (rB1.Checked == true)
                    dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 1, pageNumber, numberRecord);
                if (rB2.Checked == true)
                    dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 2, pageNumber, numberRecord);
            }
            if (dataGridViewListCustomer.RowCount <= numberRecord)
            {
                btnPrevious.Visible = false;
                btnNext.Visible = false;
            }

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
                txtSearch.Text = "Search...";
            dataGridViewListCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
                txtSearch.Text = "";
            dataGridViewListCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void btnDeleteRB_Click(object sender, EventArgs e)
        {
            rB1.Checked = false;
            rB2.Checked = false;
            dataGridViewListCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form_CustomerEditEvent f = new Form_CustomerEditEvent(mainform, this);
            f.Show();
        }
    }
}
