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
    public partial class UCEmployee_Delete : UserControl
    {
        Form_Restaurant mainform;
        public EmployeeBLL employeeBLL;
        List<Employee> ListEmpEdit;
        public UCEmployee_Delete(Form_Restaurant form)
        {
            employeeBLL = new EmployeeBLL();
            ListEmpEdit = new List<Employee>();
            mainform = form;
            InitializeComponent();
            loadData();
            dgvEmployee.ReadOnly = true;
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

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Username";
            column.Name = "Username";
            column.Visible = false;
            dgvEmployee.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Password";
            column.Name = "Password";
            column.Visible = false;
            dgvEmployee.Columns.Add(column);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void brnComeback_Click(object sender, EventArgs e)
        {
            mainform.loadUCEmployee();
        }

        private void dGvEmployeeDelate_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
            emp.Password = (string)temp.Cells["Pasword"].Value;
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

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            bool result = true;
            DialogResult dialog = MessageBox.Show("Are you sure you want to delete?", "Cancel Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)
            {
                foreach (DataGridViewRow item in this.dgvEmployee.SelectedRows)
                {
                    // Delete Datagridview
                    //dgvTable.Rows.RemoveAt(item.Index);
                    var itemToDelete = (Employee)item.DataBoundItem;
                    if (employeeBLL.DeleteEmployee(itemToDelete.EmployeeID) == false)
                    {
                        result = false;
                        break;
                    }
                }

                if (result == false)
                    MessageBox.Show("Cannot save. Please try again!");
                else
                {
                    MessageBox.Show("Saved successfully!");
                    mainform.loadUCEmployee();
                }

            }
        }
    }
}
