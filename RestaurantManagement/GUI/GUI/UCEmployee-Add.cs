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
using BCrypt;
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

        private string Create_Username(string s)
        {
            string result = "";
            s = s.ToLower();
            char[] charArr = s.ToCharArray();
            int tmp = s.LastIndexOf(" ");
            for (int i = tmp + 1; i < s.Length; i++)
            {
                result += charArr[i];
            }
            result += charArr[0];
            for (int i = 1; i < tmp; i++)
            {
                if (charArr[i].Equals(' ') == true)
                {
                    result += charArr[i + 1];
                }
            }
            result += "_";
            if (cbIsAdmin.Checked == true)
                result += "QL";
            else
                result += "NV";
            MessageBox.Show(result);
            return result;
        }

        private string Create_Password(string name, DateTime DOB)
        {
            string result = "";
            name = name.ToLower();
            char[] charArr = name.ToCharArray();
            int tmp = name.LastIndexOf(" ");
            for (int i = tmp + 1; i < name.Length; i++)
            {
                result += charArr[i];
            }
            if (DOB.Day < 10)
                result += '0';
            result += Convert.ToString(DOB.Day);
            if (DOB.Month < 10)
                result += '0';
            result += Convert.ToString(DOB.Month);
            string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(result, mySalt);
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAddress.Text) || String.IsNullOrEmpty(txtCMND.Text)
                || String.IsNullOrEmpty(txtPhone.Text) || String.IsNullOrEmpty(txtName.Text)
                || String.IsNullOrEmpty(txtEmail.Text)|| cbGender.Text == "-select-" 
                || String.IsNullOrEmpty(dtpDOB.Text))
            {
                MessageBox.Show("Please insert information fully !", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                errorGender.Text = "error";
                errorCMND.Text = "error";
                errorEmail.Text = "error";
                errorPhone.Text = "error";
            }
            else
            {
                Employee emp = new Employee();
                string Name = txtName.Text;
                while (Name.IndexOf("  ") != -1)
                {
                    Name = Name.Replace("   ", " ");
                }
                Name = Name.Trim();
                emp.Name = Name;
                emp.CMND = txtCMND.Text;
                emp.PhoneNumber = txtPhone.Text;
                emp.Address = txtAddress.Text;
                if (cbGender.Text == "Female")
                    emp.IsFemale = true;
                if (cbGender.Text == "Male")
                    emp.IsFemale = false;
                emp.Email = txtEmail.Text;
                emp.Username = Create_Username(Name);
                emp.Password = Create_Password(Name, dtpDOB.Value);
                emp.Status = 1;
                MessageBox.Show(emp.Password);
                emp.IsAdmin = (cbIsAdmin.Checked == true) ? true : false;
                emp.DateOfBirth = dtpDOB.Value;

                if (employeeBLL.AddEmployee(emp) == true)
                {
                    DialogResult dialog = MessageBox.Show("Saved successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialog == DialogResult.OK)  //click ok thì chuyển lại form đầu.
                    {
                        mainform.loadUCEmployee();
                    }
                }
                else
                {
                    MessageBox.Show("Saved unsuccessfully. Please try again!");
                }

            }
        }

        private void txtClear_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtCMND.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            dtpDOB.Text = "";
            cbGender.SelectedText = "";
            cbIsAdmin.Checked=false;
            errorCMND.Text = "";
            errorEmail.Text = "";
            errorGender.Text = "";
            errorPhone.Text = "";
        }

        private void btnComeback_Click_1(object sender, EventArgs e)
        {
            mainform.loadUCEmployee();
        }

        private void txtPhone_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                errorPhone.Text = "";
                e.Handled = true;
            }
            else
                errorPhone.Text = "error";
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex mRegxExpression;

            if (txtEmail.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(txtEmail.Text.Trim()))

                {
                    errorEmail.Text = "E-mail address format is not correct !";
                    txtEmail.Focus();
                }
            }
        }

        private void txtCMND_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                errorCMND.Text = "";
                e.Handled = true;
            }
            else
                errorCMND.Text = "error";
        }
    }
}
