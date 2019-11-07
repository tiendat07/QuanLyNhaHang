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
using Bunifu;
using DataAccessLayer;
using System.Net;

namespace GUI
{
    public partial class UCMenu_Edit : UserControl
    {
        FoodDrinkBLL foodDrinkBLL;
        Form_Restaurant mainform;
        public UCMenu_Edit(Form_Restaurant form1)
        {
            foodDrinkBLL = new FoodDrinkBLL();
            mainform = form1;
            InitializeComponent();
            LoadData();
        }
        public void Load(List<FoodDrink> lstFood, bool isFood)
        {

            int count = 0;
            int x = 0, y = 10, z = 0;
            int width = 70, height = 70;
            foreach (FoodDrink item in lstFood)
            {
                PictureBox picBox = new PictureBox();
                Label labelName = new Label();
                Label description = new Label();

                if (count % 2 == 0)
                {
                    picBox.Location = new Point(x, y);
                    labelName.Location = new Point(x + width + 8, y);
                    description.Location = new Point(x + width + 8, y + 30);
                    x += 300;
                }
                else
                {
                    picBox.Location = new Point(x, y);
                    labelName.Location = new Point(x + width + 8, y);
                    description.Location = new Point(x + width + 8, y + 30);
                    y += 100;
                    x = 0;
                }

                labelName.Text = item.FoodDrinkName;
                labelName.AutoSize = false;
                labelName.Width = 150;
                labelName.Height = 20;
                labelName.Font = new Font("SVN-Avo", 11);
                labelName.ForeColor = Color.Black;


                description.Text = item.Description;
                description.Font = new Font("SVN-Avo", 8);
                description.ForeColor = Color.Black;
                description.Width = 120;
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
            List<FoodDrink> lstFoodDrink = foodDrinkBLL.GetListFoodDrink();
            List<FoodDrink> lstFood = new List<FoodDrink>();
            List<FoodDrink> lstDrink = new List<FoodDrink>();
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

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            mainform.loadUCMenuEdit();
        }
    }
}
