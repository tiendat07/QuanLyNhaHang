using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using BLL;
namespace GUI
{
    public partial class UCTable_Edit : UserControl
    {
        TableBLL tableBLL;
        Form_Restaurant mainform;
        public UCTable_Edit(Form_Restaurant form1)
        {
            mainform = form1;
            tableBLL = new TableBLL();
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            List<Table> lstTable = tableBLL.GetListTable();
            foreach (Table item in lstTable)
            {
                myButton btn = new myButton();
                myTextEdit txt = new myTextEdit();

                btn.objectID = item.TableID;
                txt.objectID = item.TableID;

                btn.Width = flpTable1.Width / 4;
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
                            // Trống
                            btn.BackColor = Color.FromArgb(247, 204, 217);
                            btn.FlatAppearance.BorderColor = Color.FromArgb(247, 204, 217);
                            break;
                        }
                    case 1:
                        {
                            // Đã được đặt
                            btn.BackColor = Color.FromArgb(248, 168, 60);
                            btn.FlatAppearance.BorderColor = Color.FromArgb(248, 168, 60);
                            break;
                        }
                    case 2:
                        {
                            // Có người ngồi
                            btn.BackColor = Color.FromArgb(228, 76, 73);
                            btn.FlatAppearance.BorderColor = Color.FromArgb(228, 76, 73);
                            break;
                        }
                }
                
                btn.Enabled = false;
                txt.Width = btn.Width;
                txt.Height = btn.Height;
                txt.Text = item.TableName;
                txt.Font = new Font("SVN-Avo", 8f);
                Point p = btn.Location;
                txt.Location = new Point(p.X -10, p.Y-10);
                txt.Visible = true;
                txt.Enabled = true;
                //btn.Click += new EventHandler(Table_Click);
                flpTable1.Controls.Add(btn);
                flpTable1.Controls.Add(txt);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
