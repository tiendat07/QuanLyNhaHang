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
        }
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


        private void dgvCustomer_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void dgvCustomer_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
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
    }
}
