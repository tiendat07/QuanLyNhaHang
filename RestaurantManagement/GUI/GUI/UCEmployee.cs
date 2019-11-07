using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BLL;

namespace GUI
{
    public partial class UCEmployee : UserControl
    {
        Form_Restaurant mainform;

        public EmployeeBLL employeeBLL;
        public UCEmployee(Form_Restaurant form)
        {
            employeeBLL = new EmployeeBLL();
            mainform = form;
            InitializeComponent();
            loadData();
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
        }
        private void dataGridViewListEmployee_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = 20;    // <<this line will help you
        }
        private void dataGridViewListEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(this.dataGridViewListEmployee.Columns[e.ColumnIndex].Name=="Gender")
            {
                if (e.Value != null)
                {
                    int gender = Convert.ToInt32(e.Value);
                    if (gender == 1)
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
            /*
            DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
            CheckBox chk = new CheckBox();
            CheckboxColumn.Width = 20;
            CheckboxColumn.Name = "Admin";
            CheckboxColumn.HeaderText = "Admin";
            CheckboxColumn.ValueType = typeof(bool);
            if (this.dataGridViewListEmployee.Columns[e.ColumnIndex].Name == "Is Admin")
            {
                if (e.Value != null)
                {
                    int isAd = Convert.ToInt32(e.Value);
                    if (isAd == 1)
                    {
                        CheckboxColumn.TrueValue = true;
                    }
                    else
                    {
                        CheckboxColumn.TrueValue = false;
                    }
                    e.FormattingApplied = true;
                }
            }
            dataGridViewListEmployee.Columns.Add(CheckboxColumn);*/
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mainform.loadUCEmployeeEdit();
        }
        /*
int pageNumber = 1;
int numberRecord = 10;

List<Employee> result = new List<Employee>();
using (RestaurantContext bd= new EmployeeDataContext())
{
result = bd.
private void numericUpDown1_ValueChanged(object sender, EventArgs e)
{

}
*/
    }
}