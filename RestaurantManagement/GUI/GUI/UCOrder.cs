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
    public partial class UCOrder : UserControl
    {
        FoodDrinkBLL foodDrinkBLL;
        OrderBLL orderBLL;
        TableBLL tableBLL;
        OrderDetailBLL orderDetailBLL;
        Form_Restaurant mainform;
        int EmpID;
        int TabID;
        int CusID;
        List<OrderDetail> lsOrderDetail;
        Order orDer;
        bool readOnly;
        public UCOrder(Form_Restaurant form,List<OrderDetail> orderDetails, int EmployeeID, int TableID, bool ReadOnly)
        {
            readOnly = ReadOnly;
            tableBLL = new TableBLL();
            orDer = new Order();
            orderBLL = new OrderBLL();
            orderDetailBLL = new OrderDetailBLL();
            foodDrinkBLL = new FoodDrinkBLL();
            EmpID = EmployeeID;
            TabID = TableID;
            mainform = form;
            lsOrderDetail = orderDetails;
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            if (readOnly == true)
            {
                btnSave.Visible = false;
                btnSave.Enabled = false;
                btnCancel.Visible = false;
                btnCancel.Enabled = false;
            }
            var dateNow = DateTime.Now;
            var date = dateNow.ToString("dd/MM/yyyy");
            lbDateOrder.Text = Convert.ToString(date);
            lbEmployeeID.Text = Convert.ToString(EmpID);
            lbTableID.Text = Convert.ToString(TabID);

            // Order
            orDer.CustomerID = 10;
            orDer.EmployeeID = EmpID;
            orDer.IsPaid = false;
            orDer.TableID = TabID;
            orDer.OrderDate = dateNow;
            float total = 0;
            foreach (var item in lsOrderDetail)
                total += (item.Price * item.Quantity);
            orDer.Total = total;


            dataGridViewOrder.AutoGenerateColumns = false;
            dataGridViewOrder.DataSource = lsOrderDetail;
            dataGridViewOrder.ReadOnly = false;
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "OrderID";
            column.Name = "Order ID";
            column.Visible = false;
            dataGridViewOrder.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "FoodDrinkID";
            column.Name = "Food Drink Name";
            dataGridViewOrder.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Quantity";
            column.Name = "Quantity";
            dataGridViewOrder.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Note";
            column.Name = "Note";
            dataGridViewOrder.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Price";
            column.Name = "Price";
            dataGridViewOrder.Columns.Add(column);

            dataGridViewOrder.Columns[0].ReadOnly = true;
            dataGridViewOrder.Columns[1].ReadOnly = true;
            dataGridViewOrder.Columns[2].ReadOnly = true;
            dataGridViewOrder.Columns[4].ReadOnly = true;
            dataGridViewOrder.Columns[3].ReadOnly = false;
        }
        

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to save?", "Save Notification", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...
                bool Check = false;
                if (orderBLL.AddOrder(orDer, lsOrderDetail) == true)
                {
                    if (tableBLL.ChangeTableStatus(TabID, true, false, false) == true)
                    {
                        Table table = tableBLL.FindTableById(TabID);
                        if (table.Status == 1)
                        {
                            // Bàn này đang được order và khách đến và order
                            CustomerBLL customerBLL = new CustomerBLL();
                            if (customerBLL.DeleteCustomer(CusID) == true)
                                Check = true;
                        }
                        else
                            Check = true;
                    }
                }
                if (Check == true)
                {
                    MessageBox.Show("Saved sucessfully");
                    mainform.loadUCTable();
                }
                else
                    MessageBox.Show("Cannot save. Please try again!");
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            mainform.loadUcMenu_Order(TabID);
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to save?", "Save Notification", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...
                // Lưu mọi thứ xuống database
                mainform.loadUCTable();
            }
        }

        private void dataGridViewOrder_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridViewOrder.Columns[e.ColumnIndex].Name == "Food Drink Name")
            {
                if (e.Value != null)
                {

                    int ID = Convert.ToInt32(e.Value);
                    e.Value = foodDrinkBLL.GetFoodDrinkName(ID);
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataGridViewOrder_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            var temp = dataGridViewOrder.Rows[e.RowIndex];
            int id = (int)temp.Cells["Order ID"].Value;
            string note = (string)temp.Cells["Note"].Value;
            foreach (var item in lsOrderDetail)
                if (item.FoodDrinkID == id)
                    item.Note = note;
            // Edit Data (NOTE)
        }
    }
}
