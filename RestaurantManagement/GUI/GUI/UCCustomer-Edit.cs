using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DataAccessLayer;
using System.Data.OleDb;

namespace GUI
{
    public partial class UCCustomer_Edit : UserControl
    {
        Form_Restaurant mainform;
        public CustomerBLL customerBLL;
        List<Customer> ListCtmEdit;
        DataGridView data;
        public DataGridView GetDataGridView()
        {
            return data;
        }
        public UCCustomer_Edit(Form_Restaurant form, DataGridView dgv)
        {
            customerBLL = new CustomerBLL();
            ListCtmEdit = new List<Customer>();
            mainform = form;
            InitializeComponent();
            //loadData();
            dgvCustomer.ReadOnly = false;
            loadData();
            dgvCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
            this.dgvCustomer.Columns["ID"].Visible = false;
        }
        int pageNumber = 1;
        int numberRecord = 15;
        public void loadData()
        {
            dgvCustomer.AutoGenerateColumns = false;
            List<Customer> lstCustomer = customerBLL.GetListCustomer();
            dgvCustomer.DataSource = lstCustomer;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CustomerID";
            column.Name = "ID";
            column.Visible = false;
            dgvCustomer.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Name";
            column.Visible = true;
            dgvCustomer.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "IsFemale";
            column.Name = "Gender";

            dgvCustomer.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CMND";
            column.Name = "CMND";
            dgvCustomer.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "PhoneNumber";
            column.Name = "Phone";
            dgvCustomer.Columns.Add(column);
            dgvCustomer.Columns["Gender"].ReadOnly = true;
        }



        private void btnSave_Click_1(object sender, EventArgs e)
        {
            bool result = false;
            foreach (var item in ListCtmEdit)
            {
                if (customerBLL.EditCustomer(item) == false)
                {
                    MessageBox.Show("Cannot save. Please try again");
                    break;
                }
                else
                    result = true;
            }
            if (result == true)
            {
                DialogResult dialog = MessageBox.Show("Saved successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    mainform.loadUCCustomer();
                }
            }
            //dgvCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void btnComeback_Click(object sender, EventArgs e)
        {
            mainform.loadUCCustomer();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbSearch.Text == "(...)")
            {
                if (txtSearch.Text != "")
                    dgvCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 0, pageNumber, numberRecord);
                else
                {
                    dgvCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
                    btnPrevious.Visible = true;
                    btnNext.Visible = true;
                }
            }
            else
            {
                btnPrevious.Visible = false;
                btnNext.Visible = false;
            }
            if (txtSearch.Text != "")
            {
                if (rB1.Text == "Male" && rB1.Checked == true)
                    dgvCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 3, pageNumber, numberRecord);
                if (rB2.Text == "Female" && rB2.Checked == true)
                    dgvCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 4, pageNumber, numberRecord);
            }
            else
            {
                if (rB1.Text == "Male" && rB1.Checked == true)
                    dgvCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 1, pageNumber, numberRecord);
                if (rB2.Text == "Female" && rB2.Checked == true)
                    dgvCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 2, pageNumber, numberRecord);
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
                txtSearch.Text = "";
            dgvCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
                txtSearch.Text = "Search...";
            dgvCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            btnPrevious.Visible = true;
            btnNext.Visible = true;
            rB1.Checked = false;
            rB2.Checked = false;
            dgvCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void rB1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search..." || txtSearch.Text == "")
            {
                if (rB1.Checked == true)
                    dgvCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 1, pageNumber, numberRecord);
            }
            else
            {
                if (rB1.Checked == true)
                    dgvCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 3, pageNumber, numberRecord);
            }
            if (dgvCustomer.Columns.Count > numberRecord)
            {
                dgvCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
            }
        }

        private void rB2_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search..." || txtSearch.Text == "")
            {
                if (rB2.Checked == true)
                    dgvCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 2, pageNumber, numberRecord);
            }
            else
            {
                if (rB2.Checked == true)
                    dgvCustomer.DataSource = customerBLL.Sreach(txtSearch.Text, 4, pageNumber, numberRecord);
            }
        }

        private void cbSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbSearch.Text == "Gender")
            {
                btnPrevious.Visible = false;
                btnNext.Visible = false;
                rB1.Checked = false;
                rB2.Checked = false;
                rB1.Visible = true;
                rB2.Visible = true;
                rB1.Text = "Male";
                rB2.Text = "Female";
            }
            if (cbSearch.Text == "(...)")
            {
                btnPrevious.Visible = true;
                btnNext.Visible = true;
                rB1.Checked = false;
                rB2.Checked = false;
                rB1.Visible = false;
                rB2.Visible = false;
                dgvCustomer.DataSource = customerBLL.GetListCustomer();
                dgvCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pageNumber - 1 > 0)
            {
                pageNumber--;
                dgvCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalRecord = 0;
            using (RestaurantContextEntities db = new RestaurantContextEntities())
            {
                totalRecord = db.Employees.Count();
            }
            if (pageNumber -1 < totalRecord / numberRecord)
            {
                pageNumber++;
                dgvCustomer.DataSource = customerBLL.LoadRecord(pageNumber, numberRecord);

            }
        }

        private void dgvCustomer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var tctm = dgvCustomer.Rows[e.RowIndex];
            Customer ctm = new Customer();
            ctm.CustomerID = (int)tctm.Cells["ID"].Value;
            ctm.Name = (string)tctm.Cells["Name"].Value;
            bool genDer = (bool)tctm.Cells["Gender"].Value;
            ctm.IsFemale = genDer;
            ctm.PhoneNumber = (string)tctm.Cells["Phone"].Value;
            ctm.CMND = (string)tctm.Cells["CMND"].Value;
            ListCtmEdit.Add(ctm);
        }

        private void dgvCustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvCustomer.Columns[e.ColumnIndex].Name == "Gender")
            {
                if (e.Value != null)
                {
                    int gender = Convert.ToInt32(e.Value);
                    if (gender == 0)
                    {
                        e.Value = "Male";
                    }
                    else
                    {
                        e.Value = "Female";
                    }
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
