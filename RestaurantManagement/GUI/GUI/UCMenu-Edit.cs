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
        List<myLabelEdit> lslabelName;
        List<myLabelEdit> lsdescription;
        List<myButtonEdit> lspicBox;
        List<myButtonEdit> lspicDelete;
        List<myTextEdit> lstxtName;
        List<myTextEdit> lstxtDes;
        public UCMenu_Edit(Form_Restaurant form1)
        {
            foodDrinkBLL = new FoodDrinkBLL();
            lslabelName = new List<myLabelEdit>();
            lsdescription = new List<myLabelEdit>();
            lspicBox = new List<myButtonEdit>();
            lspicDelete = new List<myButtonEdit>();
            lstxtName = new List<myTextEdit>();
            lstxtDes = new List<myTextEdit>();
            mainform = form1;
            InitializeComponent();
            LoadData();
        }
        private void ButtonDeleteClick (object sender, EventArgs e)
        {
            myButtonEdit btn = sender as myButtonEdit;
            MessageBox.Show(btn.objectID + "Button Clicked");
        }
        public void Load(List<FoodDrink> lstFood, bool isFood)
        {

            int count = 0;
            int x = 0, y = 10, z = 0;
            int width = 80, height = 80;
            foreach (FoodDrink item in lstFood)
            {
                int foodID = item.FoodDrinkID;
                //Visible Item
                myButtonEdit picBox = new myButtonEdit();
                myButtonEdit picDelete = new myButtonEdit();
                myLabelEdit labelName = new myLabelEdit();
                myLabelEdit description = new myLabelEdit();

                //Invisible Item
                myTextEdit txtName = new myTextEdit();
                myTextEdit txtDescription = new myTextEdit();
                // Location? Why not appear?
                panel_Food.Controls.Add(txtName);


                picDelete.objectID = foodID;



                x = (count % 2 == 0) ? 0 : x + 500;
                // Location
                picBox.Location = new Point(x, y);
                labelName.Location = new Point(x + width + 10, y);
                description.Location = new Point(x + width + 10, y + 30);
                picDelete.Location = new Point(x + width +220, y);
                txtName.Location = new Point(x + width + 10, y);
                txtDescription.Location = new Point(x + width + 10, y + 30);
                // Sau 2 món thì Xuống dòng
                if (count % 2 != 0)
                    y += 100;

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
                
                // PicDelete
                picDelete.ImageLocation = @"C:\Users\Thien Ngan\Documents\Project\RestaurantManagement\GUI\GUI\Resources\delete_64px.png";
                picDelete.Name = "FoodDel" + foodID;
                picDelete.ClientSize = new Size(40, 40);
                picDelete.SizeMode = PictureBoxSizeMode.StretchImage;

                //TextName
                txtName.Text = item.FoodDrinkName;
                txtName.Size = new Size(200, 30);
                txtName.Name = "Text" + foodID;
                txtName.Width = 200;
                txtName.Height = 15;
                txtName.Font = new Font("SVN-Avo", 15);
                txtName.ForeColor = Color.Black;
                txtName.Visible = false;
                txtName.BorderStyle = BorderStyle.None;

                //TextDes
                txtDescription.Text = item.Description;
                txtDescription.Name = "Text" + foodID;
                txtDescription.Size = new Size(200,50);
                txtDescription.Width = 200;
                txtDescription.Height = 70;
                txtDescription.Font = new Font("SVN-Avo", 15);
                txtDescription.ForeColor = Color.Black;
                txtDescription.Visible = false;
                txtDescription.Multiline = true;
                txtDescription.BorderStyle = BorderStyle.None;

                picBox.Click += new EventHandler(ButtonChangePic);
                picDelete.Click += new EventHandler(ButtonDeleteClick);
                //btnEdit.Click += new EventHandler(btnEdit_Click);

                // List
                lslabelName.Add(labelName);
                lsdescription.Add(description);
                lspicBox.Add(picBox);
                lspicDelete.Add(picDelete);
                lstxtName.Add(txtName);
                lstxtDes.Add(txtDescription);
                if (isFood == true)
                {
                    panel_Food.Controls.Add(picBox);
                    panel_Food.Controls.Add(labelName);
                    panel_Food.Controls.Add(description);
                    panel_Food.Controls.Add(picDelete);
                    panel_Food.Controls.Add(txtName);
                    panel_Food.Controls.Add(txtDescription);
                }
                else
                {
                    panel_Drink.Controls.Add(picBox);
                    panel_Drink.Controls.Add(labelName);
                    panel_Drink.Controls.Add(description);
                    panel_Drink.Controls.Add(picDelete);
                    panel_Drink.Controls.Add(txtName);
                    panel_Drink.Controls.Add(txtDescription);
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
        
        private void ButtonChangePic(object sender, EventArgs e)
        {
            //ShowDialog
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            //LabelName
            foreach (var item in lslabelName)
                item.Visible = false;
            foreach (var item in lsdescription)
                item.Visible = false;
            foreach (var item in lstxtDes)
                item.Visible = true;
            foreach (var item in lstxtName)
                item.Visible = true;
            // Event click của mỗi item?
        }
    }
}
