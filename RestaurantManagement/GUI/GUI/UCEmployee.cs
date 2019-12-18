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
        private Form_Loading splashScreen = new Form_Loading();
        List<Employee> lstEmployee;
        public UCEmployee(Form_Restaurant form)
        {
            employeeBLL = new EmployeeBLL();
            mainform = form;
            InitializeComponent();
            //splashScreen.Show();
            //BackgroundWorker worker = new BackgroundWorker();
            //worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            //worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
            //     (worker_RunWorkerCompleted);
            //worker.RunWorkerAsync();
            //this.Visible = false;
            lstEmployee = employeeBLL.LoadRecord(pageNumber, numberRecord);
            loadData();
            dgvEmployee.ReadOnly = true;
            txtSearch.GotFocus += TxtSearch_GotFocus;
            dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
            this.dgvEmployee.Columns["ID"].Visible = false;
        }
        //void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    splashScreen.Close();
        //    this.Visible = true;
        //}

        //void worker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    lstEmployee =  employeeBLL.LoadRecord(pageNumber, numberRecord);
        //}

        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
                txtSearch.Text = "";
        }

        public DataGridView GetDataGridView()
        {
            return data;
        }
        public void loadData()
        {
            dgvEmployee.AutoGenerateColumns = false;

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
            data = dgvEmployee;
        }

        int pageNumber = 1;
        int numberRecord = 15;

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
            if (pageNumber < totalRecord / numberRecord)
            {
                pageNumber++;
                dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
            }
        }

        /*
        private void dgvEmployee_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }*/

        private void cbBSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbBSearch.Text == "Gender")
            {
                btnPrevious.Visible = false;
                btnNext.Visible = false;
                rB1.Checked = false;
                rB2.Checked = false;
                rB1.Visible = true;
                rB2.Visible = true;
                rB1.Text = "Male";
                rB2.Text = "Female";
            }
            if (cbBSearch.Text == "Type")
            {
                btnPrevious.Visible = false;
                btnNext.Visible = false;
                rB1.Checked = false;
                rB2.Checked = false;
                rB1.Visible = true;
                rB2.Visible = true;
                rB1.Text = "Admin";
                rB2.Text = "Employee";
            }
            if (cbBSearch.Text == "(...)")
            {
                btnPrevious.Visible = true;
                btnNext.Visible = true;
                rB1.Checked = false;
                rB2.Checked = false;
                rB1.Visible = false;
                rB2.Visible = false;
                dgvEmployee.DataSource = employeeBLL.GetListEmployee();
                dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
            }
        }

        private void rB1_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search..." || txtSearch.Text == "")
            {
                if (rB1.Text == "Admin" && rB1.Checked == true)
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 3,pageNumber,numberRecord);
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

        private void rB2_Click(object sender, EventArgs e)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //0: cac loai ko can phan loai,1-5:nam,2-6:nu,3-7:admin,4-8:nhanvien
            if (cbBSearch.Text == "(...)")
            {
                if (txtSearch.Text != "")
                    dgvEmployee.DataSource = employeeBLL.Sreach(txtSearch.Text, 0, pageNumber, numberRecord);
                else
                {
                    dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
                    btnPrevious.Visible = true;
                    btnNext.Visible = true;
                }
            }
            else
            {
                btnPrevious.Visible = false;
                btnNext.Visible = false;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnPrevious.Visible = true;
            btnNext.Visible = true;
            rB1.Checked = false;
            rB2.Checked = false;
            txtSearch.Text = "";
            dgvEmployee.DataSource = employeeBLL.LoadRecord(pageNumber, numberRecord);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form_EmployeeEditEvent f_event = new Form_EmployeeEditEvent(mainform, this);
            f_event.ShowDialog();
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

        /*private void dataGridViewListEmployee_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
{
e.Column.FillWeight = 20;    // <<this line will help you
}




       
    }
}*/
   