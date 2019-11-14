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
    public partial class UCEmployee_Edit : UserControl
    {
        Form_Restaurant mainform;
        public EmployeeBLL employeeBLL;
        List<Employee> ListEmpEdit;
        public UCEmployee_Edit(Form_Restaurant form)
        {
            employeeBLL = new EmployeeBLL();
            ListEmpEdit = new List<Employee>();
            mainform = form;
            InitializeComponent();
            loadData();
            
            dGvEmployee.ReadOnly = false;
            //dGvEmployee.BeginEdit(true);
            //dGvEmployee.CellEndEdit += new DataGridViewCellEventHandler(OnDataChanged);
        }
        public void loadData()
        {
            dGvEmployee.AutoGenerateColumns = false;
            List<Employee> lstEmployee = employeeBLL.GetListEmployee();
            dGvEmployee.DataSource = lstEmployee;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "EmployeeID";
            column.Name = "ID";
            column.Visible = false;
            dGvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Name";
            column.Visible = true;
            dGvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "IsFemale";
            column.Name = "Gender";

            dGvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "DateOfBirth";
            column.Name = "D.O.B";
            dGvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CMND";
            column.Name = "CMND";
            dGvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "PhoneNumber";
            column.Name = "Phone";
            dGvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Address";
            column.Name = "Address";
            dGvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Email";
            column.Name = "Email";
            dGvEmployee.Columns.Add(column);

            
            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "IsAdmin";
            column.Name = "Is Admin";
            dGvEmployee.Columns.Add(column);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (var item in ListEmpEdit)
            {
                if (employeeBLL.EditEmployee(item) == false)
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
                if (dialog == DialogResult.OK)  //click ok thì chuyển lại form đầu.
                {
                    mainform.loadUCEmployee();
                }
            }
            
        }


        private void dGvEmployee_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var temp = dGvEmployee.Rows[e.RowIndex];
            Employee emp = new Employee();
            emp.EmployeeID = (int)temp.Cells["ID"].Value;
            emp.Name = (string)temp.Cells["Name"].Value;
            emp.Address = (string)temp.Cells["Address"].Value;
            emp.CMND = (string)temp.Cells["CMND"].Value;
            emp.DateOfBirth = (DateTime)temp.Cells["D.O.B"].Value;
            emp.PhoneNumber = (string)temp.Cells["Phone"].Value;
            emp.Email = (string)temp.Cells["Email"].Value;

            emp.IsAdmin = (bool)temp.Cells["Is Admin"].Value;
            emp.Username = "a";
            emp.Password = "1";
            bool genDer = (bool)temp.Cells["Gender"].Value;
            emp.IsFemale = genDer;
            //emp.IsFemale = (genDer == "Female") ? true : false;
            // Mỗi lần sửa, người đc sửa sẽ đc đưa vào danh sách đc sửa
            ListEmpEdit.Add(emp);
        }
        

        private void dGvEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dGvEmployee.Columns[e.ColumnIndex].Name == "Gender")
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

        private void btnComeback_Click(object sender, EventArgs e)
        {
            mainform.loadUCEmployee();
        }
    }
}
