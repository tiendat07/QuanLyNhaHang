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
using System.Globalization;

namespace GUI
{
    public partial class UCOrder_Pay : UserControl
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
        public UCOrder_Pay(Form_Restaurant form, List<OrderDetail> orderDetails, int EmployeeID, int TableID, int CustomerID)
        {
            CusID = CustomerID;
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
            var dateNow = DateTime.Now;
            var date = dateNow.ToString("dd/MM/yyyy");
            lbDateOrder.Text = Convert.ToString(date);
            lbEmployeeID.Text = Convert.ToString(EmpID);
            lbTableID.Text = Convert.ToString(TabID);

            // Order
            orDer.CustomerID = CusID;
            orDer.EmployeeID = EmpID;
            orDer.IsPaid = false;
            orDer.TableID = TabID;
            orDer.OrderDate = dateNow;
            orDer.OrderID = orderBLL.FindOrderIDByTableID(TabID);
            float total = 0;
            foreach (var item in lsOrderDetail)
                total += (item.Price * item.Quantity);
            orDer.Total = total;
            lbTotal.Text = total.ToString("#,#", CultureInfo.InvariantCulture);
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
            column.Name = "Unit Price";
            dataGridViewOrder.Columns.Add(column);

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to pay?", "Pay Notification", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                myButton btn = sender as myButton;
                if (orderBLL.SetPaid(TabID) == true)
                {
                    if (tableBLL.ChangeTableStatus(TabID, false, true, false) == true)
                    {
                        MessageBox.Show("You have paid sucessfully !");
                        mainform.loadUCTable();
                    }
                    else
                        MessageBox.Show("Cannot process. Please try again");
                }
                else
                    MessageBox.Show("Cannot process. Please try again");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Form_Invoice f = new Form_Invoice();
            EmployeeBLL empBLL = new EmployeeBLL();
            Employee emp = empBLL.FindEmployee(EmpID);
            f.PrintInvoice(emp.Name, orDer, lsOrderDetail);
            f.ShowDialog();
        }

        private void dataGridViewOrder_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

            if (this.dataGridViewOrder.Columns[e.ColumnIndex].Name == "Unit Price")
            {
                if (e.Value != null)
                {
                    double Price = Convert.ToDouble(e.Value);
                    e.Value = Price.ToString("#,#", CultureInfo.InvariantCulture);
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel?", "Cancel Notification", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...
                // Lưu mọi thứ xuống database
                mainform.loadUCTable();
            }
        }
    }

}
