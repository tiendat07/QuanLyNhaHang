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
            dgvEmployee.ReadOnly = true;
            txtSearch.GotFocus += TxtSearch_GotFocus;
            dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
        }

        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
                txtSearch.Text = "";
        }

        int pageNumber = 1;
        int numberRecord = 10;

        public DataGridView GetDataGridView()
        {
            return data;
        }
        public void loadData()
        {
            dgvEmployee.AutoGenerateColumns = false;
            List<Employee> lstEmployee = employeeBLL.GetListEmployee();
            dgvEmployee.DataSource = lstEmployee;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "EmployeeID";
            column.Name = "ID";
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
            data = dgvEmployee;
        }


        private void pbEdit_Click(object sender, EventArgs e)
        {
            
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
        
        
        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            //0: cac loai ko can phan loai,1-5:nam,2-6:nu,3-7:admin,4-8:nhanvien
            if (cbBSearch.Text == "(...)")
            {
                dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text,0);
            }
            
        }

        private void dgvEmployee_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void cbBSearch_TextChanged(object sender, EventArgs e)
        {
            if(cbBSearch.Text=="Gender")
            {
                rB1.Visible = true;
                rB2.Visible = true;
                rB1.Text = "Male";
                rB2.Text = "Female";
            }
            if(cbBSearch.Text=="Type")
            {
                rB1.Visible = true;
                rB2.Visible = true;
                rB1.Text = "Admin";
                rB2.Text = "Employee";
            }
            if(cbBSearch.Text =="(...)")
            {
                rB1.Visible = false;
                rB2.Visible = false;
                dgvEmployee.DataSource = employeeBLL.GetListEmployee();
            }
        }

        private void rB1_Click(object sender, EventArgs e)
        {
            if(rB1.Text=="Admin"&&rB1.Checked==true)
            {
                if(txtSearch.Text=="Search..." || txtSearch.Text == "")
                {
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 3);
                }
                else
                {
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 7);
                }
            }
            if (rB1.Text == "Male" && rB1.Checked == true)
            {
                if (txtSearch.Text == "Search..." || txtSearch.Text == "")
                {
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 4);
                }
                else
                {
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 8);
                }
            }
        }

        private void rB2_Click(object sender, EventArgs e)
        {
            if (rB2.Text == "Employee" && rB2.Checked == true)
            {
                if (txtSearch.Text == "Search..." || txtSearch.Text == "")
                {
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 1);
                }
                else
                {
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 5);
                }
            }
            if (rB2.Text == "Female" && rB2.Checked == true)
            {
                if (txtSearch.Text == "Search..." || txtSearch.Text == "")
                {
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 2);
                }
                else
                {
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 6);
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
                txtSearch.Text = "";
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
                txtSearch.Text = "Search...";
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            Form_EmployeeEditEvent f_event = new Form_EmployeeEditEvent(mainform, this);
            f_event.Show();
        }
    }
}

        /*private void dataGridViewListEmployee_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
{
e.Column.FillWeight = 20;    // <<this line will help you
}




       
    }
}*/