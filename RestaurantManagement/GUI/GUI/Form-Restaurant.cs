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

        public static Form_Restaurant Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Form_Restaurant();
                }
                return _obj;
            }
        }
        public Form_Restaurant()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
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
        
        private void Form_Restaurant_Load(object sender, EventArgs e)
        {
        }

        private void img_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void img_Max_Click_1(object sender, EventArgs e)
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
        private void btn_Table_Click(object sender, EventArgs e)
        {
            _obj = this;
            pnlContainer.Controls.Clear();
            UCTable uc = new UCTable();
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }
    }

}
