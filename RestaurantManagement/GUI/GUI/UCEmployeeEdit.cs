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
using System.Data.SqlClient;
using System.Text.RegularExpressions;

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
            column.Visible = false;
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

            /*column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "Selected";
            column.Name = "Selected";
            dgtEmployeeEdit.Columns.Add(column);*/
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            int total = dgtEmployeeEdit.Rows.Cast<DataGridViewRow>().Where(p => Convert.ToBoolean(p.Cells["Selected"].Value) == true).Count();
            if (total > 0)
            {
                string message = $"Are you sure want to delete {total} row?";
                if (total > 1)
                    message = $"Are you sure want to delete {total +1} rows";
                if (MessageBox.Show(message, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    /*for (int i = dgtEmployeeEdit.RowCount - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = dgtEmployeeEdit.Rows[i];
                        //Check row selected
                        if (Convert.ToBoolean(row.Cells["Selected"].Value) == true)
                        {
                            dgtEmployeeEdit.Rows.Remove(row);
                        }
                    }
                    List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
                    foreach (DataGridViewRow row in dgtEmployeeEdit.Rows)
                    {
                        //DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                        if (Convert.ToBoolean(row.Cells["Selected"].Value) == true)
                            rowsToDelete.Add(row);
                    }
                    //loop through the list to delete rows added to list<T>:
                    foreach (DataGridViewRow row in rowsToDelete)
                        dgtEmployeeEdit.Rows.Remove(row);*/
                }
            }
           
    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(txtAddress.Text) || String.IsNullOrEmpty(txtCMND.Text)
                || String.IsNullOrEmpty(txtPhone.Text)|| String.IsNullOrEmpty(txtName.Text)
                || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtShift.Text)
                || String.IsNullOrEmpty(cbGender.Text) || String.IsNullOrEmpty(dtPkDOB.Text))
            {
                MessageBox.Show("Ban hay nhap day du", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Employee emp = new Employee();
                emp.EmployeeID = dgtEmployeeEdit.RowCount + 1;
                emp.Name = txtName.Text;
                emp.CMND = txtCMND.Text;
                emp.PhoneNumber = txtPhone.Text;
                emp.Address = txtAddress.Text;
                if (cbGender.SelectedValue == "Female")
                {
                    emp.IsFemale = true;
                }
                else
                    emp.IsFemale = false;
                emp.Email = txtEmail.Text;
                emp.Username = "Ngan";
                emp.Password = "123";
                emp.IsAdmin = true;
                emp.DateOfBirth = dtPkDOB.Value;

                employeeBLL.AddEmployee(emp);
                DialogResult dialog = MessageBox.Show("Saved successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)  //click ok thì chuyển lại form đầu.
                {
                    mainform.loadUCEmployeeEdit();
                }
            
        }

            /* if (txtName.Text.Trim().Length == 0) //Nếu chưa nhập Name
             {
                 MessageBox.Show("Bạn phải nhập Name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 txtName.Focus();
                 return;
             }
             if (txtAddress.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
             {
                 MessageBox.Show("Bạn phải nhập Address", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 txtShift.Focus();
                 return;
             }
             if (txtShift.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
             {
                 MessageBox.Show("Bạn phải nhập Shift", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 txtShift.Focus();
                 return;
             }
             if (txtCMND.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lại CMND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtShift.Focus();
                return;
            }
             if (txtPhone.Text.Trim().Length == 0 )
             {
                 MessageBox.Show("Bạn phải nhập lại Phone", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 txtShift.Focus();
                 return;
             }
             */

        }

        private void dgtEmployeeEdit_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgtEmployeeEdit.Columns[e.ColumnIndex].Name == "Gender")
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
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            btnInsert.Enabled = true;
            btnInsert.Enabled = false;
        }

        private void txtShift_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            
        }

        

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
           
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;

            if (txtEmail.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(txtEmail.Text.Trim()))

                {

                    MessageBox.Show("E-mail address format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtEmail.Focus();

                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtCMND.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtShift.Text = "";
            dtPkDOB.Text = "";   //vẫn chưa thay doi 
            cbGender.SelectedText = "";//ko ổn
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dgtEmployeeEdit.ReadOnly = false;
            dgtEmployeeEdit.BeginEdit(true);
        }


        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }


    }
}
