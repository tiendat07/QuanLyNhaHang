using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using BLL;
namespace GUI
{
    public partial class Form_AddFood : Form
    {
        FoodDrinkBLL foodDrinkBLL;
        Form_Restaurant mainform;
        public Form_AddFood(Form_Restaurant f)
        {
            mainform = f;
            foodDrinkBLL = new FoodDrinkBLL();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtDes.Text) 
                || String.IsNullOrEmpty(lbURLText.Text) || String.IsNullOrEmpty(cbAvailable.Text) 
                || String.IsNullOrEmpty(cbFoodDrink.Text))
            {
                MessageBox.Show("Please insert fully information of Food/Drink");
            }
            else
            {
                FoodDrink f = new FoodDrink();
                f.FoodDrinkName = txtName.Text;
                f.Description = txtDes.Text;
                f.ImageURL = lbURLText.Text;
                string isFood = cbFoodDrink.Text;
                f.IsFood = (isFood == "Food") ? true : false;
                string isAvailable = cbAvailable.Text;
                f.IsAvailable = (isAvailable == "Available") ? true : false;
                if (f.FoodDrinkID == 0)
                {
                    if (foodDrinkBLL.AddFoodDrink(f) == true)
                    {
                        MessageBox.Show("Saved successfully");
                        this.Hide();
                        mainform.loadUCMenuEdit();
                    }
                        
                    else
                        MessageBox.Show("Cannot save. Please try again!");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel?", "Cancel Notification", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...
                this.Hide();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    openFileDialog.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif";
                    lbURLText.Text = openFileDialog.FileName;
                    lbURLText.Visible = true;
                }
            }
        }
    }
}
