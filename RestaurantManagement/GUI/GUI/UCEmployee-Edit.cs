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

            dgvEmployee.ReadOnly = false;
            //dGvEmployee.BeginEdit(true);
            //dGvEmployee.CellEndEdit += new DataGridViewCellEventHandler(OnDataChanged);
        }
        public void loadData()
        {
            dgvEmployee.AutoGenerateColumns = false;
            List<Employee> lstEmployee = employeeBLL.GetListEmployee();
            dgvEmployee.DataSource = lstEmployee;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "EmployeeID";
            column.Name = "ID";
            column.Visible = false;
            dgvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Name";
            column.Visible = true;
            dgvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "IsFemale";
            column.Name = "Gender";

            dgvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "DateOfBirth";
            column.Name = "D.O.B";
            dgvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CMND";
            column.Name = "CMND";
            dgvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "PhoneNumber";
            column.Name = "Phone";
            dgvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Address";
            column.Name = "Address";
            dgvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Email";
            column.Name = "Email";
            dgvEmployee.Columns.Add(column);

            
            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "IsAdmin";
            column.Name = "Is Admin";
            dgvEmployee.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "Username";
            column.Name = "Username";
            column.Visible = false;
            dgvEmployee.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "Password";
            column.Name = "Password";
            column.Visible = false;
            dgvEmployee.Columns.Add(column);
        }
        
        
        
        private void btnSave_Click_1(object sender, EventArgs e)
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

        private void btnComeback_Click_1(object sender, EventArgs e)
        {
            mainform.loadUCEmployee();
        }
        

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvEmployee_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var temp = dgvEmployee.Rows[e.RowIndex];
            Employee emp = new Employee();
            emp.EmployeeID = (int)temp.Cells["ID"].Value;
            emp.Name = (string)temp.Cells["Name"].Value;
            emp.Address = (string)temp.Cells["Address"].Value;
            emp.CMND = (string)temp.Cells["CMND"].Value;
            emp.DateOfBirth = (DateTime)temp.Cells["D.O.B"].Value;
            emp.PhoneNumber = (string)temp.Cells["Phone"].Value;
            emp.Email = (string)temp.Cells["Email"].Value;

            emp.IsAdmin = (bool)temp.Cells["Is Admin"].Value;
            emp.Username = (string)temp.Cells["Username"].Value;
            emp.Password = (string)temp.Cells["Password"].Value;
            emp.IsFemale = (bool)temp.Cells["Gender"].Value;
            // Mỗi lần sửa, người đc sửa sẽ đc đưa vào danh sách đc sửa
            ListEmpEdit.Add(emp);
        }

        private void dgvEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvEmployee.Columns[e.ColumnIndex].Name == "Gender")
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
