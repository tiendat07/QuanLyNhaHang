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
            this.dgvEmployee.Columns["ID"].Visible = false;
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
        int numberRecord = 20;


        private void brnComeback_Click(object sender, EventArgs e)
        {
            mainform.loadUCEmployee();
        }
        
        /*private void dgvEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }*/

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
                if (txtSearch.Text == "Search...")
                    dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
            }
        }

        private void rB1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search..." || txtSearch.Text == "")
            {
                if (rB1.Text == "Admin" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 3, pageNumber, numberRecord);
                if (rB1.Text == "Male" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 1, pageNumber, numberRecord);
            }
            else
            {
                if (rB1.Text == "Admin" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 7, pageNumber, numberRecord);
                if (rB1.Text == "Male" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 5, pageNumber, numberRecord);
            }
        }

        private void rB2_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search..." || txtSearch.Text == "")
            {
                if (rB2.Text == "Employee" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 4, pageNumber, numberRecord);
                if (rB2.Text == "Female" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 2, pageNumber, numberRecord);
            }
            else
            {
                if (rB2.Text == "Employee" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 8, pageNumber, numberRecord);
                if (rB2.Text == "Female" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 6, pageNumber, numberRecord);
            }
        }

        private void btnDeletetxt_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //0: cac loai ko can phan loai,1-5:nam,2-6:nu,3-7:admin,4-8:nhanvien
            if (cbSearch.Text == "(...)" && txtSearch.Text != "")
            {
                dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
            }
            if (cbSearch.Text == "(...)")
            {
                dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 0, pageNumber, numberRecord);
            }
            if (txtSearch.Text != "")
            {
                if (rB1.Text == "Admin" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 7, pageNumber, numberRecord);
                if (rB1.Text == "Male" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 5, pageNumber, numberRecord);
                if (rB2.Text == "Employee" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 8, pageNumber, numberRecord);
                if (rB2.Text == "Female" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 6, pageNumber, numberRecord);
            }
            else
            {
                if (rB1.Text == "Admin" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 3, pageNumber, numberRecord);
                if (rB1.Text == "Male" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 1, pageNumber, numberRecord);
                if (rB2.Text == "Employee" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 4, pageNumber, numberRecord);
                if (rB2.Text == "Female" && rB2.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 2, pageNumber, numberRecord);
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
                txtSearch.Text = "Search...";
            dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
                txtSearch.Text = "";
            dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
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
