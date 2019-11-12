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
namespace GUI
{
    public partial class UCEmployeeEdit : UserControl
    {
        Form_Restaurant mainform;
        public EmployeeBLL employeeBLL;
        public UCEmployeeEdit(Form_Restaurant form)
        {
            employeeBLL = new EmployeeBLL();
            mainform = form;
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            dgtEmployeeEdit.AutoGenerateColumns = false;
            List<Employee> lstEmployee = employeeBLL.GetListEmployee();
            dgtEmployeeEdit.DataSource = lstEmployee;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "EmployeeID";
            column.Name = "ID";
            dgtEmployeeEdit.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Name";
            column.Visible = true;
            dgtEmployeeEdit.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "IsFemale";
            column.Name = "Gender";

            dgtEmployeeEdit.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "DateOfBirth";
            column.Name = "D.O.B";
            dgtEmployeeEdit.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CMND";
            column.Name = "CMND";
            dgtEmployeeEdit.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "PhoneNumber";
            column.Name = "Phone";
            dgtEmployeeEdit.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Address";
            column.Name = "Address";
            dgtEmployeeEdit.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Email";
            column.Name = "Email";
            dgtEmployeeEdit.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "IsAdmin";
            column.Name = "Is Admin";
            column.Visible = false;
            dgtEmployeeEdit.Columns.Add(column);

            column = new DataGridViewButtonColumn();
            column.HeaderText = "Delete";
            column.Name = "btn";
            //column.UseColumnTextForButtonValue = true;
            dgtEmployeeEdit.Columns.Add(column);
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

    }
}
