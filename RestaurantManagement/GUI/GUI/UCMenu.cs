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
        public UCMenu(Form_Restaurant form1)
        {
            foodDrinkBLL = new FoodDrinkBLL();
            mainform = form1;
            InitializeComponent();
            LoadData();
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
        
        private void btnEditFood_Click_1(object sender, EventArgs e)
        {
            mainform.loadUCMenuEdit();
        }
    }
}
