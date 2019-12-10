using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DataAccessLayer;
namespace GUI
{
    public partial class Form_ChangePassword : Form
    {
        EmployeeBLL employeeBLL;
        int EmployeeID;
        Employee employee;
        public Form_ChangePassword(int EmployeeID)
        {
            employeeBLL = new EmployeeBLL();
            employee = employeeBLL.FindEmployee(EmployeeID);
            InitializeComponent();
        }
        private bool CheckPassword(string password)
        {
            if (password.Length <= 8)
                return false;
            return true;
        }

        private bool ValidateOldPassword()
        {
            bool bStatus = true;
            if (txtOldPassword.Text == "")
            {
                errorProvider1.SetError(txtOldPassword, "Please enter your  Password");
                bStatus = false;
            }
            else if (employeeBLL.CheckPassword(EmployeeID, txtOldPassword.Text) == false)
            {
                errorProvider1.SetError(txtOldPassword, "Your password was incorrect. You should enter your current password.");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(txtOldPassword, "");
                bStatus = true;
            }
            return bStatus;
        }

        private void txtOldPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidateOldPassword();
        }

        private bool ValidatePassword()
        {
            bool bStatus = true;
            if (txtNewPassword.Text == "")
            {
                errorProvider1.SetError(txtNewPassword, "Please enter your new Password");
                bStatus = false;
            }
            else if (CheckPassword(txtNewPassword.Text) == false)
            {
                errorProvider1.SetError(txtNewPassword, "Invalid Password. Your password must be at least 8 characters long");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, "");
                bStatus = true;
            }
            return bStatus;
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidatePassword();
        }

        private bool ValidateNewPassword()
        {
            bool bStatus = true;
            if (txtNewPassword.Text == "")
            {
                errorProvider1.SetError(txtReNewPassword, "Please enter your new Password");
                bStatus = false;
            }
            else if (txtReNewPassword.Text != txtNewPassword.Text)
            {
                errorProvider1.SetError(txtReNewPassword, "Invalid password. Your re-type password must match your new password");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(txtReNewPassword, "");
                bStatus = true;
            }
            return bStatus;
        }

        private void txtReNewPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidateNewPassword();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            //Revalidate the controls
            bool success = ValidateOldPassword();
            if (success) success = ValidatePassword();
            if (success) success = ValidateNewPassword();
            if (success)
            {
                string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
                employee.Password = BCrypt.Net.BCrypt.HashPassword(txtNewPassword.Text, mySalt);
                if (employeeBLL.EditEmployee(employee) == true)
                {
                    MessageBox.Show("Success!");
                    this.Close();
                }
                else
                    MessageBox.Show(":( Unsuccess. Please try again baby!");
            }
            else
                MessageBox.Show(":( Unsuccess. Please try again baby!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to cancel?", "Cancel Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)  //click ok thì chuyển lại form đầu.
            {
                this.Close();
            }
        }
    }
}
