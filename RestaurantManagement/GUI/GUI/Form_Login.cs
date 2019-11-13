﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace GUI
{
    public partial class Form_Login : Form
    {
        public EmployeeBLL employeeBLL;
        public Form_Login()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            employeeBLL = new EmployeeBLL();
            InitializeComponent();
        }

        private void img_Min_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void img_Max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void img_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string tenDN = txtUsername.Text;
            string matkhau = txtPassword.Text;

            if (string.IsNullOrEmpty(tenDN) || string.IsNullOrEmpty(matkhau))
            {
                MessageBox.Show("Vui long nhap day du thong tin");
            }
            else
            {
                if (employeeBLL.CheckLogin(tenDN, matkhau) == true)
                {
                    Form_Restaurant f = new Form_Restaurant();
                    this.Hide();
                    f.Show();
                }
                else
                    MessageBox.Show("Chua chinh xac !!");
                
            }
        }

        private void Form_Login_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string tenDN = txtUsername.Text;
                string matkhau = txtPassword.Text;

                if (string.IsNullOrEmpty(tenDN) || string.IsNullOrEmpty(matkhau))
                {
                    MessageBox.Show("Vui long nhap day du thong tin");
                }
                else
                {
                    if (employeeBLL.CheckLogin(tenDN, matkhau) == true)
                    {
                        Form_Restaurant f = new Form_Restaurant();
                        this.Hide();
                        f.Show();
                    }
                    else
                        MessageBox.Show("Chua chinh xac !!");

                }
            }
                
        }
    }
}
