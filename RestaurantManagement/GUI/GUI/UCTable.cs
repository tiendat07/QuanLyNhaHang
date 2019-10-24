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
using GUI.ServiceReferenceRestaurant;
using DataAccessLayer;
namespace GUI
{
    public partial class UCTable : UserControl
    {
        TableBLL tableBLL;
        public UCTable()
        {
            tableBLL = new TableBLL();
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            CustomerServiceClient cus = new CustomerServiceClient();
            Table[] lstTable = cus.GetListTable();
            //List<Table> lstTable = 
            //List<Table> lstTable = tableBLL.GetListTable();
            foreach (Table item in lstTable)
            {
                var btn = new Bunifu.Framework.UI.BunifuThinButton2();
                btn.Width = 70;
                btn.Height = 40;
                btn.ButtonText = item.TableName;
                btn.Font = new Font("SVN-Avo", 8f);
                btn.IdleForecolor = Color.White;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.ActiveForecolor = Color.White;
                btn.IdleCornerRadius = 10;
                switch (item.Status)
                {
                    case 0:
                        {
                            btn.BackColor = Color.Transparent;
                            btn.IdleFillColor = Color.FromArgb(247, 204, 217);
                            btn.IdleLineColor = Color.FromArgb(247, 204, 217);
                            btn.ActiveFillColor = Color.FromArgb(247, 204, 217);
                            btn.ActiveLineColor = Color.FromArgb(247, 204, 217);
                            break;
                        }
                    case 1:
                        {
                            btn.BackColor = Color.Transparent;
                            btn.IdleFillColor = Color.FromArgb(248, 168, 60);
                            btn.IdleLineColor = Color.FromArgb(248, 168, 60);
                            btn.ActiveFillColor = Color.FromArgb(248, 168, 60);
                            btn.ActiveLineColor = Color.FromArgb(248, 168, 60);
                            break;
                        }
                    case 2:
                        {
                            btn.BackColor = Color.Transparent;
                            btn.IdleFillColor = Color.FromArgb(228, 76, 73);
                            btn.IdleLineColor = Color.FromArgb(228, 76, 73);
                            btn.ActiveFillColor = Color.FromArgb(228, 76, 73);
                            btn.ActiveLineColor = Color.FromArgb(228, 76, 73);
                            break;
                        }
                }

                flpTable1.Controls.Add(btn);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {

        }
    }
}
