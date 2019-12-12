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
            dGvCustomer.ReadOnly = false;
            loadData();
        }
        public void loadData()
        {
            dGvCustomer.AutoGenerateColumns = false;
            List<Customer> lstCustomer = customerBLL.GetListCustomer();
            dGvCustomer.DataSource = lstCustomer;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CustomerID";
            column.Name = "ID";
            column.Visible = false;
            dGvCustomer.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Name";
            column.Visible = true;
            dGvCustomer.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "IsFemale";
            column.Name = "Gender";

            dGvCustomer.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CMND";
            column.Name = "CMND";
            dGvCustomer.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "PhoneNumber";
            column.Name = "Phone";
            dGvCustomer.Columns.Add(column);
            dGvCustomer.Columns["Gender"].ReadOnly = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach(var item in ListCtmEdit)
            {
                if (customerBLL.EditCustomer(item) == false)
                {
                    MessageBox.Show("Can't save !! Please try again");
                    break;
                }
                else
                    result = true;
            }
            if(result==true)
            {
                DialogResult dialog = MessageBox.Show("Save successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    mainform.loadUCCustomer();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainform.loadUCCustomer();
        }

        private void dGvCustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dGvCustomer.Columns[e.ColumnIndex].Name == "Gender")
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

        private void dGvCustomer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var tctm = dGvCustomer.Rows[e.RowIndex];
            Customer ctm = new Customer();
            ctm.CustomerID = (int)tctm.Cells["ID"].Value;
            ctm.Name = (string)tctm.Cells["Name"].Value;
            bool genDer = (bool)tctm.Cells["Gender"].Value;
            ctm.IsFemale = genDer;
            ctm.PhoneNumber = (string)tctm.Cells["Phone"].Value;
            ctm.CMND = (string)tctm.Cells["CMND"].Value;
            ListCtmEdit.Add(ctm);
        }

        private void dGvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
