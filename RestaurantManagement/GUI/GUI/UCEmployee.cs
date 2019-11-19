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
    public partial class UCEmployee : UserControl
    {
        Form_Restaurant mainform;
        DataGridView data;
        public EmployeeBLL employeeBLL;

        public UCEmployee(Form_Restaurant form)
        {
            employeeBLL = new EmployeeBLL();
            mainform = form;
            InitializeComponent();
            loadData();
            dataGridViewListEmployee.ReadOnly = true;
        }
        public DataGridView GetDataGridView()
        {
            return data;
        }
        public void loadData()
        {
            dataGridViewListEmployee.AutoGenerateColumns = false;
            List<Employee> lstEmployee = employeeBLL.GetListEmployee();
            dataGridViewListEmployee.DataSource = lstEmployee;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "EmployeeID";
            column.Name = "ID";
            dataGridViewListEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Name";
            column.Visible = true;
            dataGridViewListEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "IsFemale";
            column.Name = "Gender";
            
            dataGridViewListEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "DateOfBirth";
            column.Name = "D.O.B";
            dataGridViewListEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CMND";
            column.Name = "CMND";
            dataGridViewListEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "PhoneNumber";
            column.Name = "Phone";
            dataGridViewListEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Address";
            column.Name = "Address";
            dataGridViewListEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Email";
            column.Name = "Email";
            dataGridViewListEmployee.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "IsAdmin";
            column.Name = "Is Admin";
            dataGridViewListEmployee.Columns.Add(column);
            data = dataGridViewListEmployee;
        }
        private void dataGridViewListEmployee_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = 20;    // <<this line will help you
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            Form_EmployeeEditEvent f_event = new Form_EmployeeEditEvent(mainform, this);
            f_event.Show();
        }

        private void dataGridViewListEmployee_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridViewListEmployee.Columns[e.ColumnIndex].Name == "Gender")
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form_EmployeeEditEvent f = new Form_EmployeeEditEvent(mainform, this);
            f.Show();
            //mainform.loadUCEmployeeEdit();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}