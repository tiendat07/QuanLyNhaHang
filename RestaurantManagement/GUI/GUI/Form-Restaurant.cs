using DataAccessLayer;
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
        UCEmployee ucEmployee;
        UCCustomer ucCustomer;
        static bool AdminTrue;
        static int EmployeeID;
        public static Form_Restaurant Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Form_Restaurant(AdminTrue, EmployeeID);
                }
                return _obj;
            }
        }
        public Form_Restaurant(bool isAdmin, int ID)
        {
            InitializeComponent();
            AdminTrue = isAdmin;
            EmployeeID = ID;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            if (AdminTrue == false)
            {
                btn_Employee.Visible = false;
                btn_Employee.Enabled = false;
            }
            this.LoadUCHome();
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

        public void loadUCEmployee()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCEmployee uc = new UCEmployee(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        public void loadUCEmployeeEdit()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCEmployee_Edit uc = new UCEmployee_Edit(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        public void loadUCEmployeeEvenEdit()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCEmployeeEvenEdit uc = new UCEmployeeEvenEdit(this, ucEmployee);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        public void loadUCEmployeeDelate()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCEmployee_Delete uc = new UCEmployee_Delete(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        public void loadUCEmployeeAdd()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCEmployee_Add uc = new UCEmployee_Add(this, ucEmployee.GetDataGridView());
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }
    

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
            ucEmployee = uc;
        }

        private void btn_Customer_Click(object sender, EventArgs e)
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCCustomer uc = new UCCustomer(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
            ucCustomer = uc;
        }
        public void loadUCCustomer()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCCustomer uc = new UCCustomer(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }
        public void loadUCCustomer_Add()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCCustomer_Add uc = new UCCustomer_Add(this, ucCustomer.GetDataGridView());
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }
        public void loadUCCustomer_Edit()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCCustomer_Edit uc = new UCCustomer_Edit(this, ucCustomer.GetDataGridView());
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        public void loadUCOrder(List<OrderDetail> orderDetails, int TableID, bool ReadOnly)
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCOrder uc = new UCOrder(this, orderDetails, EmployeeID, TableID, ReadOnly);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        public void loadUcMenu_Order(int TableID)
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCMenu_Order uc = new UCMenu_Order(this, EmployeeID, TableID);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCHome uc = new UCHome(this, EmployeeID);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void Form_Restaurant_Load_1(object sender, EventArgs e)
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCHome uc = new UCHome(this, EmployeeID);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }
        public void LoadUCHome()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCHome uc = new UCHome(this, EmployeeID);
        }
        private void Form_Restaurant_Activated(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        public void loadUCTable()
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCTable uc = new UCTable(this);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);

        }
    }

}
