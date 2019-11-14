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
            dGvEmployeeDelate.ReadOnly = true;
        }

        public void loadData()
        {
            dGvEmployeeDelate.AutoGenerateColumns = false;
            List<Employee> lstEmployee = employeeBLL.GetListEmployee();
            dGvEmployeeDelate.DataSource = lstEmployee;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "EmployeeID";
            column.Name = "ID";
            column.Visible = false;
            dGvEmployeeDelate.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Name";
            column.Visible = true;
            dGvEmployeeDelate.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "IsFemale";
            column.Name = "Gender";

            dGvEmployeeDelate.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "DateOfBirth";
            column.Name = "D.O.B";
            dGvEmployeeDelate.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CMND";
            column.Name = "CMND";
            dGvEmployeeDelate.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "PhoneNumber";
            column.Name = "Phone";
            dGvEmployeeDelate.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Address";
            column.Name = "Address";
            dGvEmployeeDelate.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Email";
            column.Name = "Email";
            dGvEmployeeDelate.Columns.Add(column);


            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "IsAdmin";
            column.Name = "Is Admin";
            dGvEmployeeDelate.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Username";
            column.Name = "Username";
            column.Visible = false;
            dGvEmployeeDelate.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Password";
            column.Name = "Password";
            //column.Visible = false;
            dGvEmployeeDelate.Columns.Add(column);
        }

        private void dGvEmployeeDelate_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var temp = dGvEmployeeDelate.Rows[e.RowIndex];
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
            bool genDer = (bool)temp.Cells["Gender"].Value;
            emp.IsFemale = genDer;
            //emp.IsFemale = (genDer == "Female") ? true : false;
            // Mỗi lần sửa, người đc sửa sẽ đc đưa vào danh sách đc sửa
            ListEmpEdit.Add(emp);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (var item in ListEmpEdit)
            {
                if (employeeBLL.DeleteEmployee(item.EmployeeID) == false)
                {
                    MessageBox.Show("Cannot save. Please try again");
                    break;
                }
                else
                    result = true;
            }
            if (result == true)
            {
                //save thanh cong! ban co muon o lai trang
                DialogResult dialog = MessageBox.Show("Saved successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)  //click ok thì chuyển lại form đầu.
                {
                    mainform.loadUCEmployee();
                }
            }

        }

        private void brnComeback_Click(object sender, EventArgs e)
        {
            mainform.loadUCEmployee();
        }

        private void dGvEmployeeDelate_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dGvEmployeeDelate.Columns[e.ColumnIndex].Name == "Gender")
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
