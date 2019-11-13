﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using GUI.ServiceReferenceRestaurant;
using DataAccessLayer;
namespace GUI
{
    public partial class UCTable : UserControl
    {
        TableBLL tableBLL;
        Form_Restaurant mainform;
        List<Table> lsTable_temp;
        public UCTable(Form_Restaurant form1)
        {
            tableBLL = new TableBLL();
            lsTable_temp = tableBLL.GetListTable();
            mainform = form1;
            InitializeComponent();
            LoadData();
        }
        private void Table_Click(object sender, EventArgs e)
        {
            myButton btn = sender as myButton;
            foreach (var item in lsTable_temp)
            {
               
                if (item.TableID == btn.objectID)
                {
                    switch (item.Status)
                    {
                        case 0:
                            {
                                // Trống
                                btnOrder.Visible = true;
                                btnOrder.Enabled = true;
                                btnPay.Visible = false;
                                btnPay.Enabled = false;
                                //btnBook.Visible = true;
                                //btnBook.Visible = true;
                                break;
                            }
                        case 1:
                            {
                                // Đã có ng đặt
                                btnPay.Visible = true;
                                btnPay.Enabled = true;
                                btnOrder.Visible = false;
                                btnOrder.Enabled = false;
                                break;
                            }
                        case 2:
                            {
                                // Đã có người vô ngồi
                                btnPay.Visible = true;
                                btnPay.Enabled = true;
                                btnOrder.Visible = false;
                                btnOrder.Enabled = false;
                                break;
                            }
                    }
                }
            }
        }
        public void LoadData()
        {
            //CustomerServiceClient cus = new CustomerServiceClient();
            //Table[] lstTable = cus.GetListTable();
            btnBook.Visible = false;
            btnBook.Enabled = false;
            btnOrder.Visible = false;
            btnOrder.Enabled = false;
            btnPay.Visible = false;
            btnPay.Enabled = false;
            List<Table> lstTable = tableBLL.GetListTable();
            foreach (Table item in lstTable)
            {
                myButton btn = new myButton();
                btn.objectID = item.TableID;
                btn.Width = flpTable1.Width/4;
                btn.Height = 50;
                btn.Text = item.TableName;
                btn.Font = new Font("SVN-Avo", 8f);
                btn.ForeColor = Color.White;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                switch (item.Status)
                {
                    case 0:
                        {
                            btn.BackColor = Color.FromArgb(247, 204, 217);
                            btn.FlatAppearance.BorderColor = Color.FromArgb(247, 204, 217);
                            break;
                        }
                    case 1:
                        {
                            btn.BackColor = Color.FromArgb(248, 168, 60);
                            btn.FlatAppearance.BorderColor = Color.FromArgb(248, 168, 60);
                            break;
                        }
                    case 2:
                        {
                            btn.BackColor = Color.FromArgb(228, 76, 73);
                            btn.FlatAppearance.BorderColor = Color.FromArgb(228, 76, 73);
                            break;
                        }
                }
                btn.Click += new EventHandler(Table_Click);
                
                flpTable1.Controls.Add(btn);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            //mainform.loadUCTableEdit();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            mainform.loadUcMenu_Order();
            this.Hide();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to pay?", "Pay Notification", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...
                MessageBox.Show("You have paid sucessfully !");
            }
        }
    }
}
