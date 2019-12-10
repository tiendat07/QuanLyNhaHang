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

        private void dataGridViewListCustomer_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
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
        
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            Form_CustomerEditEvent f = new Form_CustomerEditEvent(mainform, this);
            f.Show();
        }

        private void dataGridViewListCustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridViewListCustomer.Columns[e.ColumnIndex].Name == "Gender")
            {
                if (e.Value != null)
                {
                    bool gender = Convert.ToBoolean(e.Value);
                    if (gender == true)
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
        private void cbSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbSearch.Text == "Gender")
            {
                rB1.Checked = false;
                rB2.Checked = false;
                rB1.Visible = true;
                rB2.Visible = true;
                rB1.Text = "Male";
                rB2.Text = "Female";
            }
            if (cbSearch.Text == "(...)")
            {
                rB1.Checked = false;
                rB2.Checked = false;
                rB1.Visible = false;
                rB2.Visible = false;
                dataGridViewListCustomer.DataSource = customerBLL.GetListCustomer();
                dataGridViewListCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
            }
        }

        private void rB1_CheckedChanged(object sender, EventArgs e)
        {//male
            if (txtSearch.Text == "Search..." || txtSearch.Text == "")
            {
                    dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 1);
            }
            else
            {
                dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 3);
            }
            if (dataGridViewListCustomer.RowCount <= numberRecord)
            {
                btnPrevious.Visible = false;
                btnNext.Visible = false;
            }
        }

        private void rB2_CheckedChanged(object sender, EventArgs e)
        {//female
            if (txtSearch.Text == "Search..." || txtSearch.Text == "")
            {
                dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 2);
            }
            else
            {
                dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 4);
            }
            if (dataGridViewListCustomer.RowCount <= numberRecord)
            {
                btnPrevious.Visible = false;
                btnNext.Visible = false;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
                txtSearch.Text = "";
            dataGridViewListCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
                txtSearch.Text = "Search...";
            dataGridViewListCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            //0: cac loai ko can phan loai,1-3:nam,2-4:nu
            if (cbSearch.Text == "(...)" && txtSearch.Text != "")
            {
                dataGridViewListCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
            }
            if (cbSearch.Text == "(...)")
            {
                dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 0);
            }
            if (txtSearch.Text != "")
            {
                if (rB1.Checked == true)
                    dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 3);
                if (rB2.Checked == true)
                    dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 4);
            }
            else
            {
                if (rB1.Checked == true)
                    dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 1);
                if (rB2.Checked == true)
                    dataGridViewListCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 2);
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
    }
}
