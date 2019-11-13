using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_Restaurant : Form
    {
        static Form_Restaurant _obj;
        static bool  AdminTrue;
        public static Form_Restaurant Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Form_Restaurant(AdminTrue);
                }
                return _obj;
            }
        }
        public Form_Restaurant(bool isAdmin)
        {
            AdminTrue = isAdmin;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            // int width = SystemInformation.VirtualScreen.Width;
            //int height = SystemInformation.VirtualScreen.Height;
            //this.Size = new Size(width, height);
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            if (AdminTrue == false)
            {
                btn_Employee.Visible = false;
                btn_Employee.Enabled = false;
                btn_Order.Visible = false;
                btn_Order.Enabled = false;
            }
        }
        private const int cGrip = 16;
        private const int cCaption = 32;
        protected override void WndProc (ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }
        

        private void img_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void img_Max_Click_1(object sender, EventArgs e)
        {
            // Nhưng Normal là như thế nào?
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
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
        public Panel PnlContainer
        {
            get { return pnlContainer; }
            set { pnlContainer = value; }
        }
        public void loadUCMenuEdit()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCMenu_Edit uc = new UCMenu_Edit(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }
        
        public void loadUCTableEdit()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCTable_Edit uc = new UCTable_Edit(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }
        

        //public void loadUCEmployeeEdit()
        //{
        //    _obj = this;
        //    pnlContainer.Controls.Clear();
        //    UCEmployeeEdit uc = new UCEmployeeEdit(this);
        //    uc.Dock = DockStyle.Fill;
        //    pnlContainer.Controls.Add(uc);
        //}

        private void btn_Menu_Click_1(object sender, EventArgs e)
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCMenu uc = new UCMenu(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void btn_Table_Click_1(object sender, EventArgs e)
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCTable uc = new UCTable(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void btn_Employee_Click_1(object sender, EventArgs e)
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCEmployee uc = new UCEmployee(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void btn_Customer_Click(object sender, EventArgs e)
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCCustomer uc = new UCCustomer(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }
        public void loadUCCustomer2()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCCustomer2 uc = new UCCustomer2(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void btn_Order_Click(object sender, EventArgs e)
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCOrder uc = new UCOrder(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }
        public void loadUcMenu_Order()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCMenu_Order uc = new UCMenu_Order(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }
        public void loadUCOrder()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCOrder uc = new UCOrder(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCHome uc = new UCHome(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void Form_Restaurant_Load_1(object sender, EventArgs e)
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCHome uc = new UCHome(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }
    }

}
