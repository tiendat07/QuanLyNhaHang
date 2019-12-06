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
        List<Table> tables;
        public UCTable_Edit(Form_Restaurant form1)
        {
            mainform = form1;
            tables = new List<Table>();
            tableBLL = new TableBLL();
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            dgvTable.AutoGenerateColumns = false;
            List<Table> lstEmployee = tableBLL.GetListTable();
            dgvTable.DataSource = lstEmployee;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "TableID";
            column.Name = "ID";
            dgvTable.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "TableName";
            column.Name = "Name";
            dgvTable.Columns.Add(column);
            dgvTable.Columns["ID"].ReadOnly = true;
        }

        private void dgvTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Chưa xét trường hợp nhiều dòng
            var temp = dgvTable.Rows[e.RowIndex];
            Table table = new Table();
            table.TableID = (int)temp.Cells["ID"].Value;
            table.TableName = (string)temp.Cells["Name"].Value;
            tables.Add(table);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (var item in tables)
            {
                if (tableBLL.EditTable(item) == false)
                {
                    MessageBox.Show("Cannot save. Please try again");
                    break;
                }
                else
                    result = true;
            }
            if (result == true)
            {
                DialogResult dialog = MessageBox.Show("Saved successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)  //click ok thì chuyển lại form đầu.
                {
                    mainform.loadUCEmployee();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to cancel?", "Cancel Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)  //click ok thì chuyển lại form đầu.
            {
                mainform.loadUCTable();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = true;
            DialogResult dialog = MessageBox.Show("Are you sure you want to delete?", "Cancel Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK) 
            {
                foreach (DataGridViewRow item in this.dgvTable.SelectedRows)
                {
                    // Delete Datagridview
                    //dgvTable.Rows.RemoveAt(item.Index);
                    var itemToDelete = (Table)item.DataBoundItem;
                    if (tableBLL.DeleteTable(itemToDelete.TableID) == false)
                    {
                        result = false;
                        break;
                    }
                }
                if (result == false)
                    MessageBox.Show("Cannot save. Please try again!");
                else
                {
                    MessageBox.Show("Saved successfully!");
                    mainform.loadUCTableEdit();
                }
                    
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<Table> tables = tableBLL.GetListTable();
            int index = tables.Count() +1;
            Table new_table = new Table();
            new_table.TableName = "Bàn " + index;
            if (tableBLL.AddTable(new_table) == true)
            {
                mainform.loadUCTableEdit();
            }
        }
    }
}
