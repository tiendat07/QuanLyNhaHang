using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DataAccessLayer;
namespace GUI
{
    public partial class Form_FoodDrink : Form
    {
        FoodDrinkBLL foodBLL;
        public Form_FoodDrink()
        {
            foodBLL = new FoodDrinkBLL();
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    openFileDialog.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif";
                    lbLink.Text = openFileDialog.FileName;

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtDes.Text) || String.IsNullOrEmpty(lbLink.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else;
            {
                FoodDrink food = new FoodDrink();
                food.FoodDrinkName = txtName.Text;
                food.ImageURL = lbLink.Text;
                food.Description = txtDes.Text;
                // Thêm các combobox: isAvailable, isFood và ID?
                if (foodBLL.AddFoodDrink(food) == true)
                {
                    MessageBox.Show("Saved Successfully");
                    this.Close();
                }
                else
                    MessageBox.Show("Cannot save. Please try again !");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel?", "Cancel Notification", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...
                this.Close();
            }
        }
    }
}
