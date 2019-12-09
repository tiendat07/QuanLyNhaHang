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
        }

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

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {

        }
    }
}
