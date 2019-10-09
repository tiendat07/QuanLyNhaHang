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
using Model;
namespace GUI
{
    public partial class ucTable1 : UserControl
    {
        TableBLL tableBLL;
        public ucTable1()
        {
            tableBLL = new TableBLL();
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            //dataGridView1.AutoGenerateColumns = false;
            //List<Table> lstTable = tableBLL.GetListTable();
            //dataGridView1.DataSource = lstTable;

            //DataGridViewColumn column = new DataGridViewTextBoxColumn();
            //column.DataPropertyName = "TableName";
            //column.Name = "Tên bàn";
            //dataGridView1.Columns.Add(column);


            //column = new DataGridViewTextBoxColumn();
            //column.DataPropertyName = "Status";
            //column.Name = "Trạng thái";
            //dataGridView1.Columns.Add(column);
        }
    }
}
