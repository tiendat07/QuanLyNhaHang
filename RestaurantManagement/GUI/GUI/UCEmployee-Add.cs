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
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class UCEmployee_Add : UserControl
    {
        Form_Restaurant mainform;
        public EmployeeBLL employeeBLL;
        DataGridView datagrid;

        public UCEmployee_Add(Form_Restaurant form, DataGridView data)
        {
            datagrid = data;
            employeeBLL = new EmployeeBLL();
            mainform = form;
            InitializeComponent();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAddress.Text) || String.IsNullOrEmpty(txtCMND.Text)
                || String.IsNullOrEmpty(txtPhone.Text) || String.IsNullOrEmpty(txtName.Text)
                || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtShift.Text)
                || String.IsNullOrEmpty(cbGender.Text) || String.IsNullOrEmpty(dtpkDOB.Text))
                
            {
                MessageBox.Show("Please insert information fully !", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Employee emp = new Employee();
                emp.EmployeeID = datagrid.RowCount + 1;
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

                emp.IsAdmin = (cbIsAdmin.Checked == true) ? true : false;
                emp.DateOfBirth = dtpkDOB.Value;

                employeeBLL.AddEmployee(emp);
                DialogResult dialog = MessageBox.Show("Saved successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)  //click ok thì chuyển lại form đầu.
                {
                    mainform.loadUCEmployee();
                }
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtCMND.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtShift.Text = "";
            dtpkDOB.Text = "";
            cbGender.SelectedText = "";
        }

        private void txtShift_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void btnComeback_Click(object sender, EventArgs e)
        {
            mainform.loadUCEmployee();
        }

    }
}
