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
    public partial class Form_Profile : Form
    {
        int EmpID;
        EmployeeBLL employeeBLL;
        public Form_Profile(int EmployeeID)
        {
            InitializeComponent();
            EmpID = EmployeeID;
            employeeBLL = new EmployeeBLL();
            ReadOnly();
            LoadData();
        }
        public void ReadOnly()
        {
            txtName.Enabled = false;
            cbGender.Enabled = false;
            dtpDOB.Enabled = false;
            txtPhoneNumber.Enabled = false;
            txtAddress.Enabled = false;
            txtCMND.Enabled = false;
            txtEmail.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            btnSave.Visible = false;
            btnSave.Enabled = false;
            btnCancel.Visible = false;
            btnCancel.Enabled = false;

            txtName.BackColor = Color.White;
            cbGender.BackColor = Color.White;
            dtpDOB.BackColor = Color.White;
            txtPhoneNumber.BackColor = Color.White;
            txtAddress.BackColor = Color.White;
            txtCMND.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            txtUsername.BackColor = Color.White;
            txtPassword.BackColor = Color.White;

            txtName.ForeColor = Color.Blue;
            cbGender.ForeColor = Color.Black;
            dtpDOB.ForeColor = Color.Black;
            txtPhoneNumber.ForeColor = Color.Black;
            txtAddress.ForeColor = Color.Black;
            txtCMND.ForeColor = Color.Black;
            txtEmail.ForeColor = Color.Black;
            txtUsername.ForeColor = Color.Black;
            txtPassword.ForeColor = Color.Black;

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnEdit.Enabled = false;
            txtName.Enabled = true;
            cbGender.Enabled = true;
            dtpDOB.Enabled = true;
            txtPhoneNumber.Enabled = true;
            txtAddress.Enabled = true;
            txtCMND.Enabled = true;
            txtEmail.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            btnSave.Visible = true;
            btnSave.Enabled = true;
            btnCancel.Visible = true;
            btnCancel.Enabled = true;
            
        }
        
        public void LoadData()
        {
            Employee e = employeeBLL.FindEmployee(EmpID);
            txtName.Text = e.Name;
            // Lưu ý chỗ combo box?
            cbGender.SelectedIndex = (e.IsFemale == true) ? 0 : 1;
            dtpDOB.Value = e.DateOfBirth;
            txtPhoneNumber.Text = e.PhoneNumber;
            txtAddress.Text = e.Address;
            txtCMND.Text = e.CMND;
            txtEmail.Text = e.Email;
            txtUsername.Text = e.Username;
            txtPassword.Text = e.Password;
            // Thay đổi password? : Phải mã hóa xuống liền luôn trc khi lưu xuống db?
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
                // Set Error Provider ?
            }
        }
    }
}
