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
    public partial class UCCustomer_Add : UserControl
    {
        Form_Restaurant mainform;
        public CustomerBLL customerBLL;
        DataGridView datagrid;
        public UCCustomer_Add(Form_Restaurant form, DataGridView data)
        {
            datagrid = data;
            customerBLL = new CustomerBLL();
            mainform = form;
            InitializeComponent();
        }
      
        private void txtPhone_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCMND_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCMND.Text) || cbGender.Text == "-select-"
             || String.IsNullOrEmpty(txtPhone.Text) || String.IsNullOrEmpty(txtName.Text))

            {
                MessageBox.Show("Please insert information fully !", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (lbErrorCMND.Visible == true || lbErrorGender.Visible == true
                    || lbErrorName.Visible == true || lbErrorPhone.Visible == true)
                    MessageBox.Show("Please correct your mistakes before save changes");
                else
                {
                    Customer ctm = new Customer();
                    string Name = txtName.Text;
                    while (Name.IndexOf("  ") != -1)
                    {
                        Name = Name.Replace("   ", " ");
                    }
                    Name = Name.Trim();
                    ctm.Name = Name;
                    ctm.CMND = txtCMND.Text;
                    ctm.PhoneNumber = txtPhone.Text;
                    ctm.Status = 1;
                    ctm.IsFemale = (cbGender.SelectedItem.ToString() == "Female") ? true : false;
                    if (customerBLL.AddCustomer(ctm) == true)
                    {
                        DialogResult dialog = MessageBox.Show("Saved successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dialog == DialogResult.OK)
                        {
                            mainform.loadUCCustomer();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can't save !!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
               
            }
        }

        private void btnComeback_Click(object sender, EventArgs e)
        {
            mainform.loadUCCustomer();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                lbErrorPhone.Text = "This input requires numbers only";
                e.Handled = true;
            }
            else
                lbErrorPhone.Text = "";
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCMND.TextLength < 9)
                lbErrorCMND.Text = "Incorrect input";
            else
                lbErrorCMND.Text = "";
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (txtPhone.TextLength < 10)
                lbErrorPhone.Text = "Incorrect input";
            else
                lbErrorPhone.Text = "";
        }

        private void txtCMND_Leave(object sender, EventArgs e)
        {
            if (txtCMND.TextLength < 9)
                lbErrorCMND.Text = "Incorrect input";
            else
                lbErrorCMND.Text = "";
        }
    }
}
