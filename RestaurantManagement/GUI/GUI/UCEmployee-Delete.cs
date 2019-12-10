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
            dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
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

        int pageNumber = 1;
        int numberRecord = 15;


        private void brnComeback_Click(object sender, EventArgs e)
        {
            mainform.loadUCEmployee();
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

        private void btnComeback_Click(object sender, EventArgs e)
        {
            mainform.loadUCEmployee();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pageNumber - 1 > 0)
            {
                pageNumber--;
                dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalRecord = 0;
            using (RestaurantContextEntities db = new RestaurantContextEntities())
            {
                totalRecord = db.Employees.Count();
            }
            if (pageNumber - 1 < totalRecord / numberRecord)
            {
                pageNumber++;
                dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);

            }
        }

        private void cbSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbSearch.Text == "Gender")
            {
                rB1.Checked = false;
                rB2.Checked = false;
                rB1.Visible = true;
                rB2.Visible = true;
                rB1.Text = "Male";
                rB2.Text = "Female";
            }
            if (cbSearch.Text == "Type")
            {
                rB1.Checked = false;
                rB2.Checked = false;
                rB1.Visible = true;
                rB2.Visible = true;
                rB1.Text = "Admin";
                rB2.Text = "Employee";
            }
            if (cbSearch.Text == "(...)")
            {
                rB1.Checked = false;
                rB2.Checked = false;
                rB1.Visible = false;
                rB2.Visible = false;
                dgvEmployee.DataSource = employeeBLL.GetListEmployee();
                dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
            }
        }

        private void rB1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search..." || txtSearch.Text == "")
            {
                if (rB1.Text == "Admin" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 3);
                if (rB1.Text == "Male" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 1);
            }
            else
            {
                if (rB1.Text == "Admin" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 7);
                if (rB1.Text == "Male" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 5);
            }
            if (dgvEmployee.RowCount <= numberRecord)
            {
                btnPrevious.Visible = false;
                btnNext.Visible = false;
            }
        }

        private void rB2_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search..." || txtSearch.Text == "")
            {
                if (rB2.Text == "Employee" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 4);
                if (rB2.Text == "Female" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 2);
            }
            else
            {
                if (rB2.Text == "Employee" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 8);
                if (rB2.Text == "Female" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 6);
            }
            if (dgvEmployee.RowCount <= numberRecord)
            {
                btnPrevious.Visible = false;
                btnNext.Visible = false;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
                txtSearch.Text = "";
            dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
                txtSearch.Text = "Search...";
            dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            //0: cac loai ko can phan loai,1-5:nam,2-6:nu,3-7:admin,4-8:nhanvien
            if (cbSearch.Text == "(...)" && txtSearch.Text != "")
            {
                dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
            }
            if (cbSearch.Text == "(...)")
            {
                dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 0);
            }
            if (txtSearch.Text != "")
            {
                if (rB1.Text == "Admin" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 7);
                if (rB1.Text == "Male" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 5);
                if (rB2.Text == "Employee" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 8);
                if (rB2.Text == "Female" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 6);
            }
            else
            {
                if (rB1.Text == "Admin" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 3);
                if (rB1.Text == "Male" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 1);
                if (rB2.Text == "Employee" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 4);
                if (rB2.Text == "Female" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 2);
            }
            if (dgvEmployee.RowCount <= numberRecord)
            {
                btnPrevious.Visible = false;
                btnNext.Visible = false;
            }
        }

        private void btnDeletetxt_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
        }
    }
}
