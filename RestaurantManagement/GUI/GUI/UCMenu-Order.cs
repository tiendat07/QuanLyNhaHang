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
using DataAccessLayer;
namespace GUI
{
    public partial class UCMenu_Order : UserControl
    {
        FoodDrinkBLL foodDrinkBLL;
        OrderDetailBLL orderDetailBLL;
        Form_Restaurant mainform;
        List<FoodDrink> lsFood_Order;
        List<FoodDrink> lsFood;
        List<myNumericUpDown> lsNumeric;
        List<OrderDetail> lsOrder;
        List<FoodDrink> lstFoodDrink;
        List<FoodDrink> lstFood;
        List<FoodDrink> lstDrink;
        int EmpID, TabID, CusID;
        public UCMenu_Order(Form_Restaurant form1, int EmployeeID, int TableID, int CustomerID)
        {
            lstFood = new List<FoodDrink>();
            lstDrink = new List<FoodDrink>();
            CusID = CustomerID;
            EmpID = EmployeeID;
            TabID = TableID;
            orderDetailBLL = new OrderDetailBLL();
            foodDrinkBLL = new FoodDrinkBLL();
            lsFood_Order = new List<FoodDrink>();
            lsNumeric = new List<myNumericUpDown>();
            lsFood = foodDrinkBLL.GetListFoodDrink();
            lsOrder = new List<OrderDetail>();
            mainform = form1;
            InitializeComponent();
            LoadData();
        }
        private void NumericValueChanged(object sender, EventArgs e)
        {
            myNumericUpDown n = sender as myNumericUpDown;
            foreach (var item in lsOrder)
            {
                if (item.FoodDrinkID == n.objectID)
                {
                    item.Quantity = Convert.ToInt32(n.Value);
                    item.Price = float.Parse(foodDrinkBLL.GetFoodPrice(item.FoodDrinkID).ToString());
                   // item.Price *= item.Quantity;
                }
                    
            }
            
            
        }
        private void CheckBoxClick(object sender, EventArgs e)
        {
            // Làm sao xác định đc ngta check hay uncheck??? Vì thế nào cx là click mà?
            
            myCheckBoxEdit cb = sender as myCheckBoxEdit;
            
            if (cb.Checked == true)
            {
                foreach (var item in lsNumeric)
                {
                    if (item.objectID == cb.objectID)
                    {
                        item.Visible = true;
                        item.Enabled = true;
                        btnSave.Visible = true;
                        btnSave.Enabled = true;

                        btnCancel.Visible = true;
                        btnCancel.Enabled = true;
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.FoodDrinkID = cb.objectID;
                        orderDetail.Quantity = 1;
                        orderDetail.Note = "None";
                        orderDetail.Price = (float)foodDrinkBLL.GetFoodPrice(cb.objectID);
                        //orderDetail.OrderID = 10;
                        lsOrder.Add(orderDetail);
                    }
                }
            }
            else
            {
                btnSave.Visible = false;
                btnSave.Enabled = false;

                btnCancel.Visible = false;
                btnCancel.Enabled = false;

                if (lsOrder.Any() == true)
                {
                    
                    foreach (var item in lsOrder.ToList())
                    {
                        if (item.FoodDrinkID == cb.objectID)
                         lsOrder.Remove(item);
                    }
                        
                }
            }
            
        }
        public void Load(List<FoodDrink> lstFood, bool isFood)
        {

            int count = 0;
            int x = 0, y = 10, z = 0;
            int width = 80, height = 80;
            foreach (FoodDrink item in lstFood)
            {
                if (item.IsAvailable == false)
                    continue;
                int foodID = item.FoodDrinkID;
                //Visible Item
                myButtonEdit picBox = new myButtonEdit();
                myCheckBoxEdit checkBox = new myCheckBoxEdit();
                myLabelEdit labelName = new myLabelEdit();
                myLabelEdit description = new myLabelEdit();
                myNumericUpDown number = new myNumericUpDown();
                
                checkBox.objectID = foodID;
                picBox.objectID = foodID;
                number.objectID = foodID;
                x = (count % 2 == 0) ? 0 : x + 500;
                // Location
                picBox.Location = new Point(x, y);
                labelName.Location = new Point(x + width + 10, y);
                description.Location = new Point(x + width + 10, y + 30);
                checkBox.Location = new Point(x + width + 220, y);
                number.Location = new Point(x + width + 260, y + 10);
                // Sau 2 món thì Xuống dòng
                if (count % 2 != 0)
                    y += 100;

                //Numeric
                number.Value = 1;
                number.Maximum = 20;
                number.Minimum = 1;
                number.Width = 30;

                // Label Name
                labelName.Text = item.FoodDrinkName;
                labelName.Name = "FoodName" + foodID;
                labelName.AutoSize = false;
                labelName.Width = 200;
                labelName.Height = 30;
                labelName.Font = new Font("SVN-Avo", 15);
                labelName.ForeColor = Color.Black;

                // Description
                description.Text = item.Description;
                description.Name = "FoodDes" + foodID;
                description.Font = new Font("SVN-Avo", 12);
                description.ForeColor = Color.Black;
                description.Width = 200;
                description.Height = 70;


                // PicBox
                picBox.ImageLocation = item.ImageURL;
                picBox.Name = "FoodPic" + foodID;
                picBox.ClientSize = new Size(width, height);
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;

                // checkBox
                checkBox.Name = "FoodDel" + foodID;
                checkBox.ClientSize = new Size(40, 40);
                checkBox.Width = 20;
                // List
                //lslabelName.Add(labelName);
                //lsdescription.Add(description);
                //lspicBox.Add(picBox);
                //lspicDelete.Add(picDelete);
                //lstxtName.Add(txtName);
                //lstxtDes.Add(txtDescription);

                lsNumeric.Add(number);

                checkBox.Click += new EventHandler(CheckBoxClick);
                number.ValueChanged += new EventHandler(NumericValueChanged);
                number.Visible = false;
                number.Enabled = false;
                if (isFood == true)
                {
                    panel_Food.Controls.Add(picBox);
                    panel_Food.Controls.Add(labelName);
                    panel_Food.Controls.Add(description);
                    panel_Food.Controls.Add(checkBox);
                    panel_Food.Controls.Add(number);
                }
                else
                {
                    panel_Drink.Controls.Add(picBox);
                    panel_Drink.Controls.Add(labelName);
                    panel_Drink.Controls.Add(description);
                    panel_Drink.Controls.Add(checkBox);
                    panel_Drink.Controls.Add(number);
                }
                
                count++;
            }
        }
        public void LoadData()
        {
            lstFoodDrink = foodDrinkBLL.GetListFoodDrink();
            foreach (FoodDrink item in lstFoodDrink)
            {
                if (item.IsFood == true)
                    lstFood.Add(item);
                else
                    lstDrink.Add(item);
            }
            Load(lstFood, true);
            Load(lstDrink, false);
        }
        public List<OrderDetail> GetOrderDetails()
        {
            return lsOrder;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lsOrder.Any() == true)
            {
                MessageBox.Show("Saved successfully");
                this.Hide();
                mainform.loadUCOrder(lsOrder, TabID, false, CusID);
            }
            else
            {
                MessageBox.Show("Please choose your choice");
            }
                
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch1.Text != "Search...")
            {
                List<FoodDrink> lsFood = foodDrinkBLL.Search(txtSearch1.Text, 0);
                panel_Food.Controls.Clear();
                Load(lsFood, true);
            }
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch2.Text != "Search...")
            {
                List<FoodDrink> lsDrink = foodDrinkBLL.Search(txtSearch2.Text, 1);
                panel_Drink.Controls.Clear();
                Load(lsDrink, false);
            }
        }

        private void txtSearch2_Enter(object sender, EventArgs e)
        {
            if (txtSearch2.Text == "Search...")
                txtSearch2.Text = "";
        }

        private void txtSearch1_Enter(object sender, EventArgs e)
        {
            if (txtSearch1.Text == "Search...")
                txtSearch1.Text = "";
        }

        private void txtSearch1_Leave(object sender, EventArgs e)
        {
            if (txtSearch1.Text == "")
                txtSearch1.Text = "Search...";
        }

        private void txtSearch2_Leave(object sender, EventArgs e)
        {
            if (txtSearch2.Text == "")
                txtSearch2.Text = "Search...";

        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            txtSearch1.Text = "";
            panel_Food.Controls.Clear();
            Load(lstFood, true);
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            txtSearch2.Text = "";
            panel_Drink.Controls.Clear();
            Load(lstDrink, false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel?", "Cancel Notification", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...
                this.Hide();
                //mainform.loadUCTable();
            }
        }
    }
}
