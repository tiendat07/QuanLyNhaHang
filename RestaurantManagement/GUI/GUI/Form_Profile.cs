using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DataAccessLayer;
namespace GUI
{
    public partial class Form_Profile : Form
    {
        int EmpID;
        EmployeeBLL employeeBLL;
        Employee employee;
        public Form_Profile(int EmployeeID)
        {
            InitializeComponent();
            EmpID = EmployeeID;
            employeeBLL = new EmployeeBLL();
            LoadData();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnEdit.Enabled = false;
            txtName.Visible = true;
            cbGender.Visible = true;
            dtpDOB.Visible = true;
            txtPhoneNumber.Visible = true;
            txtAddress.Visible = true;
            txtCMND.Visible = true;
            txtEmail.Visible = true;
            txtUsername.Visible = true;
            txtPassword.Visible = true;
            btnSave.Visible = true;
            btnSave.Enabled = true;
            btnCancel.Visible = true;
            btnCancel.Enabled = true;

            lbName.Visible = false;
            lbGender.Visible = false;
            lbDOB.Visible = false;
            lbPhone.Visible = false;
            lbAddress.Visible = false;
            lbCMND.Visible = false;
            lbEmail.Visible = false;
            lbUsername.Visible = false;
            lbPassword.Visible = false;

        }

        public void LoadData()
        {
            employee = employeeBLL.FindEmployee(EmpID);
            txtName.Text = employee.Name;
            // Lưu ý chỗ combo box?
            cbGender.SelectedIndex = (employee.IsFemale == true) ? 0 : 1;
            dtpDOB.Value = employee.DateOfBirth;
            txtPhoneNumber.Text = employee.PhoneNumber;
            txtAddress.Text = employee.Address;
            txtCMND.Text = employee.CMND;
            txtEmail.Text = employee.Email;
            txtUsername.Text = employee.Username;
            txtPassword.Text = employee.Password;
            // Thay đổi password? : Phải mã hóa xuống liền luôn trc khi lưu xuống db?

            lbName.Text = employee.Name;
            // Lưu ý chỗ combo box?
            lbGender.Text = (employee.IsFemale == true) ? "Female" : "Male";
            lbDOB.Text = employee.DateOfBirth.ToShortDateString().ToString();
            lbPhone.Text = employee.PhoneNumber;
            lbAddress.Text = employee.Address;
            lbCMND.Text = employee.CMND;
            lbEmail.Text = employee.Email;
            lbUsername.Text = employee.Username;
            lbPassword.Text = employee.Password;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text) || (String.IsNullOrEmpty(txtPhoneNumber.Text))
                || String.IsNullOrEmpty(txtAddress.Text) || (String.IsNullOrEmpty(txtCMND.Text))
                || String.IsNullOrEmpty(txtEmail.Text) || (String.IsNullOrEmpty(txtUsername.Text))
                || (String.IsNullOrEmpty(txtPassword.Text)))
            {
                MessageBox.Show("Please insert fully information");
            }
            else
            {
                errorProvider1.Clear();

                //Revalidate the controls
                bool success = ValidateName();
                if (success) success = ValidatePhone();
                if (success) success = ValidateAddress();
                if (success) success = ValidateCMND();
                if (success) success = ValidateEmail();
                if (success) success = ValidatePassword();

                if (success)
                {
                    employee.Name = txtName.Text;
                    employee.CMND = txtCMND.Text;
                    employee.DateOfBirth = dtpDOB.Value;
                    employee.Email = txtEmail.Text;
                    employee.Address = txtAddress.Text;
                    employee.IsFemale = (cbGender.SelectedIndex == 0) ? true : false;
                    employee.PhoneNumber = txtPhoneNumber.Text;
                    employee.Password = txtPassword.Text;
                    // Chưa mã hóa !!
                    if (employeeBLL.EditEmployee(employee) == true)
                    {
                        MessageBox.Show("Success!");
                    }
                    else
                        MessageBox.Show(":( Unsuccess. Please try again baby!");
                }
                else
                    MessageBox.Show(":( Unsuccess. Please try again baby!");
            }

        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtName.Text);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            ValidateName();
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            ValidatePhone();
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            ValidateAddress();
        }

        private void txtCMND_Validating(object sender, CancelEventArgs e)
        {
            ValidateCMND();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidatePassword();
        }
        private bool ValidateName()
        {

            bool bStatus = true;
            if (txtName.Text == "")
            {
                errorProvider1.SetError(txtName, "Please enter your Name");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(txtName, "");
                bStatus = true;
            }

            return bStatus;
        }
        private bool ValidatePhone()
        {
            bool bStatus = true;
            if (txtPhoneNumber.Text == "")
            {
                errorProvider1.SetError(txtPhoneNumber, "Please enter your Phone Number");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(txtPhoneNumber, "");
                bStatus = true;
            }
            return bStatus;
        }
        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        private bool ValidateEmail()
        {
            bool bStatus = true;
            if (txtEmail.Text == "")
            {
                errorProvider1.SetError(txtEmail, "Please enter your Email");
                bStatus = false;
            }
            else if (IsValidEmail(txtEmail.Text) == false)
            {
                errorProvider1.SetError(txtEmail, "Invalid Email");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
                bStatus = true;
            }

            return bStatus;
        }
        private bool ValidateAddress()
        {
            bool bStatus = true;
            if (txtAddress.Text == "")
            {
                errorProvider1.SetError(txtAddress, "Please enter your  Email");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(txtAddress, "");
                bStatus = true;
            }
            return bStatus;
        }
        private bool ValidateCMND()
        {
            bool bStatus = true;
            if (txtCMND.Text == "")
            {
                errorProvider1.SetError(txtCMND, "Please enter your  Email");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(txtCMND, "");
                bStatus = true;
            }
            return bStatus;
        }
        private bool CheckPassword(string password)
        {
            if (password.Length <= 8)
                return false;
            return true;
        }
        private bool ValidatePassword()
        {
            bool bStatus = true;
            if (txtPassword.Text == "")
            {
                errorProvider1.SetError(txtPassword, "Please enter your  Password");
                bStatus = false;
            }
            else if (CheckPassword(txtPassword.Text) == false)
            {
                errorProvider1.SetError(txtPassword, "Invalid Password. Your password must contains more than 8 characters");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
                bStatus = true;
            }
            return bStatus;
        }
    }
}
