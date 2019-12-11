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
using System.Net;

namespace GUI
{
    public partial class UCMenu : UserControl
    {
        FoodDrinkBLL foodDrinkBLL;
        Form_Restaurant mainform;
        List<FoodDrink> lstFoodDrink;
        List<FoodDrink> lstFood;
        List<FoodDrink> lstDrink;
        public UCMenu(Form_Restaurant form1)
        {
            foodDrinkBLL = new FoodDrinkBLL();
            lstFood = new List<FoodDrink>();
            lstDrink = new List<FoodDrink>();
            mainform = form1;
            InitializeComponent();
            LoadData();
           // txtSearch1.GotFocus += TxtSearch1_GotFocus;
            //txtSearch2.GotFocus += TxtSearch2_GotFocus;
        }

        private void TxtSearch2_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch2.Text == "Search...")
                txtSearch2.Text = "";
        }

        private void TxtSearch1_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch1.Text == "Search...")
                txtSearch1.Text = "";
        }

        public void Load (List <FoodDrink> lstFood, bool isFood)
        {

            int count = 0;
            int x = 0, y = 10, z = 0;
            int width = 80, height = 80;
            foreach (FoodDrink item in lstFood)
            {
                if (item.IsAvailable == false)
                    continue;
                PictureBox picBox = new PictureBox();
                Label labelName = new Label();
                Label description = new Label();
                
                x = (count % 2 == 0) ? 0 : x + 500;

                picBox.Location = new Point(x, y);
                labelName.Location = new Point(x + width + 10, y);
                description.Location = new Point(x + width + 10, y + 30);

                if (count % 2 != 0)
                    y += 100;

                labelName.Text = item.FoodDrinkName;
                labelName.AutoSize = false;
                labelName.Width = 200;
                labelName.Height = 30;
                labelName.Font = new Font("SVN-Avo", 15);
                labelName.ForeColor = Color.Black;


                description.Text = item.Description;
                description.Font = new Font("SVN-Avo", 12);
                description.ForeColor = Color.Black;
                description.Width = 200;
                description.Height = 50;

                picBox.ImageLocation = item.ImageURL;
                picBox.ClientSize = new Size(width, height);
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                if (isFood == true)
                {
                    panel_Food.Controls.Add(picBox);
                    panel_Food.Controls.Add(labelName);
                    panel_Food.Controls.Add(description);
                }
                else
                {
                    panel_Drink.Controls.Add(picBox);
                    panel_Drink.Controls.Add(labelName);
                    panel_Drink.Controls.Add(description);
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
        
        private void btnEditFood_Click_1(object sender, EventArgs e)
        {
            mainform.loadUCMenuEdit();
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

        private void txtSearch1_Leave(object sender, EventArgs e)
        {
            if (txtSearch1.Text == "")
                txtSearch1.Text = "Search...";
        }

        private void txtSearch1_Enter(object sender, EventArgs e)
        {
            if (txtSearch1.Text == "Search...")
                txtSearch1.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
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

        private void txtSearch2_Leave(object sender, EventArgs e)
        {
            if (txtSearch2.Text == "")
                txtSearch2.Text = "Search...";

        }

        private void txtSearch2_Enter(object sender, EventArgs e)
        {
            if (txtSearch2.Text == "Search...")
                txtSearch2.Text = "";
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
    }
}
