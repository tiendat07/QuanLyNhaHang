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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            mainform.loadUCCustomer();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCMND.Text) || cbGender.Text == "-select-"
             || String.IsNullOrEmpty(txtPhone.Text) || String.IsNullOrEmpty(txtName.Text))

            {
                MessageBox.Show("Please insert information fully !", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Customer ctm = new Customer();
                ctm.Name = txtName.Text;
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

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
