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
        string picturePath;
        Form_Restaurant mainform;
        List<myLabelEdit> lslabelName;
        List<myLabelEdit> lsdescription;
        List<myButtonEdit> lspicBox;
        List<myButtonEdit> lspicDelete;
        List<myButtonEdit> lspicEdit;
        List<myTextEdit> lstxtName;
        List<myTextEdit> lstxtDes;
        List<FoodDrink> lsFoodDrink_Temp;
        public UCMenu_Edit(Form_Restaurant form1)
        {
            foodDrinkBLL = new FoodDrinkBLL();
            lslabelName = new List<myLabelEdit>();
            lsdescription = new List<myLabelEdit>();
            lspicBox = new List<myButtonEdit>();
            lspicDelete = new List<myButtonEdit>();
            lstxtName = new List<myTextEdit>();
            lstxtDes = new List<myTextEdit>();
            lspicEdit = new List<myButtonEdit>();
            mainform = form1;
            InitializeComponent();
            btnSave.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Enabled = false;
            btnCancel.Visible = false;
            lsFoodDrink_Temp = foodDrinkBLL.GetListFoodDrink();
            LoadData();
        }
        private void ButtonDeleteClick (object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete Notification", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...
                myButtonEdit btn = sender as myButtonEdit;
                if (foodDrinkBLL.DeleteFoodDrinkByID(btn.ObjectID) == true)
                {
                    MessageBox.Show("Deleted Successfully");
                }
                else
                    MessageBox.Show("Cannot delete. Please try again!");
            }
            else if (result == DialogResult.No)
            {
                //no...
                MessageBox.Show("Cannceled");
            }
        }
        private void ButtonChangeClick(object sender, EventArgs e)
        {
            //ShowDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    openFileDialog.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif";
                    picturePath = openFileDialog.FileName;
                    myButtonEdit btn = sender as myButtonEdit;
                    //MessageBox.Show(" " + btn.objectID);
                    foreach (var item in lsFoodDrink_Temp)
                        if (item.FoodDrinkID == btn.objectID)
                            item.ImageURL = picturePath;
                    // Truy vấn xuống database để chạy lại

                }
            }
        }
        private void Name_TextChanged(object sender, EventArgs e)
        {
            myTextEdit txt = sender as myTextEdit;
            txt.objectText = txt.Text;
            //MessageBox.Show(" " + txt.objectText);
            foreach (var item in lsFoodDrink_Temp)
            {
                if (item.FoodDrinkID == txt.objectID)
                    item.FoodDrinkName = txt.objectText;
            }
        }
        private void Description_TextChanged(object sender, EventArgs e)
        {
            myTextEdit txt = sender as myTextEdit;
            txt.objectText = txt.Text;
            
            foreach (var item in lsFoodDrink_Temp)
            {
                if (item.FoodDrinkID == txt.objectID)
                {
                    item.Description = txt.Text;
                    //MessageBox.Show(" " + item.Description);
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
                int foodID = item.FoodDrinkID;
                //Visible Item
                myButtonEdit picBox = new myButtonEdit();
                myButtonEdit picDelete = new myButtonEdit();
                myLabelEdit labelName = new myLabelEdit();
                myLabelEdit description = new myLabelEdit();

                //Invisible Item
                myTextEdit txtName = new myTextEdit();
                myTextEdit txtDescription = new myTextEdit();
                myButtonEdit picEdit = new myButtonEdit();
                // Location? Why not appear?
                panel_Food.Controls.Add(txtName);


                picDelete.objectID = foodID;
                picBox.objectID = foodID;
                txtName.objectID = foodID;
                txtName.objectText = item.FoodDrinkName;
                txtDescription.objectID = foodID;
                txtDescription.objectText = item.Description;

                x = (count % 2 == 0) ? 0 : x + 500;
                // Location
                picBox.Location = new Point(x, y);
                labelName.Location = new Point(x + width + 10, y);
                description.Location = new Point(x + width + 10, y + 30);
                picDelete.Location = new Point(x + width + 220, y);
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

                // PicEdit
                picEdit.ImageLocation = @"C:\Users\Thien Ngan\Documents\Project\RestaurantManagement\GUI\GUI\Resources\browser_window_128px.png";
                picEdit.ClientSize = new Size(width, height);
                picEdit.SizeMode = PictureBoxSizeMode.StretchImage;
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
                txtDescription.Size = new Size(200, 50);
                txtDescription.Width = 200;
                txtDescription.Height = 70;
                txtDescription.Font = new Font("SVN-Avo", 15);
                txtDescription.ForeColor = Color.Black;
                txtDescription.Visible = false;
                txtDescription.Multiline = true;
                txtDescription.BorderStyle = BorderStyle.None;

                txtName.TextChanged += new EventHandler(Name_TextChanged);
                txtDescription.TextChanged += new EventHandler(Description_TextChanged);
                picBox.Click += new EventHandler(ButtonChangeClick);
                picDelete.Click += new EventHandler(ButtonDeleteClick);
                //btnEdit.Click += btnEdit_Click;

                // List
                lslabelName.Add(labelName);
                lsdescription.Add(description);
                lspicBox.Add(picBox);
                lspicDelete.Add(picDelete);
                lstxtName.Add(txtName);
                lstxtDes.Add(txtDescription);
                lspicEdit.Add(picEdit);
                if (isFood == true)
                {
                    panel_Food.Controls.Add(picBox);
                    panel_Food.Controls.Add(labelName);
                    panel_Food.Controls.Add(description);
                    panel_Food.Controls.Add(picDelete);
                    panel_Food.Controls.Add(txtName);
                    panel_Food.Controls.Add(txtDescription);
                    // panel_Food.Controls.Add(picEdit);
                }
                else
                {
                    panel_Drink.Controls.Add(picBox);
                    panel_Drink.Controls.Add(labelName);
                    panel_Drink.Controls.Add(description);
                    panel_Drink.Controls.Add(picDelete);
                    panel_Drink.Controls.Add(txtName);
                    panel_Drink.Controls.Add(txtDescription);
                    // panel_Drink.Controls.Add(picEdit);
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
        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnAdd.Visible = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;

            //LabelName

            foreach (var item in lslabelName)
                item.Visible = false;
            foreach (var item in lsdescription)
                item.Visible = false;
            //foreach (var item in lspicBox)
            //    item.Visible = false;
            foreach (var item in lstxtDes)
                item.Visible = true;
            foreach (var item in lstxtName)
                item.Visible = true;
            foreach (var item in lspicDelete)
            {
                item.Visible = false;
                item.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form_AddFood f = new Form_AddFood();
            f.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel?", "Cancel Notification", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //yes...
                this.Hide();
                mainform.loadUCMenuEdit();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = true;
            foreach (var item in lsFoodDrink_Temp)
            {
                if (foodDrinkBLL.EditFoodDrink(item) == false)
                {
                    result = false;
                    MessageBox.Show("Cannot save. Please try again");
                    break;
                }
            }
            if (result == true)
                MessageBox.Show("Saved Successfully");

        }
    }
}
