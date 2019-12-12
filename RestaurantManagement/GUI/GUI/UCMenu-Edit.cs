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
using GUI.Properties;

namespace GUI
{
    public partial class UCMenu_Edit : UserControl
    {
        bool isEdit = false;
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
        List<FoodDrink> lstFoodDrink;
        List<FoodDrink> lstFood;
        List<FoodDrink> lstDrink;
        List<myLabelEdit> lslabelPrice;
        List<myTextEdit> lstxtPrice;
        public UCMenu_Edit(Form_Restaurant form1)
        {
            lstFood = new List<FoodDrink>();
            lstDrink = new List<FoodDrink>();
            foodDrinkBLL = new FoodDrinkBLL();
            lstFoodDrink = foodDrinkBLL.GetListFoodDrink();
            lslabelName = new List<myLabelEdit>();
            lslabelPrice = new List<myLabelEdit>();
            lsdescription = new List<myLabelEdit>();
            lspicBox = new List<myButtonEdit>();
            lspicDelete = new List<myButtonEdit>();
            lstxtName = new List<myTextEdit>();
            lstxtPrice = new List<myTextEdit>();
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
            if (isEdit == true)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        openFileDialog.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif";
                        picturePath = openFileDialog.FileName;
                        myButtonEdit btn = sender as myButtonEdit;
                        foreach (var item in lsFoodDrink_Temp)
                            if (item.FoodDrinkID == btn.objectID)
                                item.ImageURL = picturePath;

                    }
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
                if (item.IsAvailable == false)
                    continue;
                int foodID = item.FoodDrinkID;
                //Visible Item
                myButtonEdit picBox = new myButtonEdit();
                myButtonEdit picDelete = new myButtonEdit();
                myLabelEdit labelName = new myLabelEdit();
                myLabelEdit description = new myLabelEdit();
                myLabelEdit labelPrice = new myLabelEdit();

                //Invisible Item
                myTextEdit txtName = new myTextEdit();
                myTextEdit txtDescription = new myTextEdit();
                myButtonEdit picEdit = new myButtonEdit();
                myTextEdit txtPrice = new myTextEdit();

                picDelete.objectID = foodID;
                picBox.objectID = foodID;
                txtName.objectID = foodID;
                txtName.objectText = item.FoodDrinkName;
                txtDescription.objectID = foodID;
                txtDescription.objectText = item.Description;
                txtPrice.objectID = foodID;

                x = (count % 2 == 0) ? 0 : x + 500;
                // Location
                picBox.Location = new Point(x, y);
                labelName.Location = new Point(x + width + 10, y);
                description.Location = new Point(x + width + 10, y + 30);
                labelPrice.Location = new Point(x + width + 210, y);
                txtName.Location = new Point(x + width + 10, y);
                txtDescription.Location = new Point(x + width + 10, y + 30);
                txtPrice.Location = new Point(x + width + 210, y);

                picDelete.Location = new Point(x + width + 300, y);
                
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

                // Label Price
                labelPrice.Text = Convert.ToString(item.FoodPrice);
                labelPrice.AutoSize = false;
                labelPrice.Width = 70;
                labelPrice.Height = 30;
                labelPrice.Font = new Font("SVN-Avo", 15);
                labelPrice.ForeColor = Color.Black;

                // PicBox
                picBox.ImageLocation = item.ImageURL;
                picBox.Name = "FoodPic" + foodID;
                picBox.ClientSize = new Size(width, height);
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;

                // PicDelete
                picDelete.Image = Resources.delete_64px;
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
                txtDescription.Size = new Size(200, 50);
                txtDescription.Width = 200;
                txtDescription.Height = 70;
                txtDescription.Font = new Font("SVN-Avo", 15);
                txtDescription.ForeColor = Color.Black;
                txtDescription.Visible = false;
                txtDescription.Multiline = true;
                txtDescription.BorderStyle = BorderStyle.None;

                // TextPrice
                txtPrice.Text = Convert.ToString(item.FoodPrice);
                txtPrice.Name = "Text" + foodID;
                txtPrice.Width = 70;
                txtPrice.Height = 15;
                txtPrice.Font = new Font("SVN-Avo", 15);
                txtPrice.ForeColor = Color.Black;
                txtPrice.Visible = false;
                txtPrice.BorderStyle = BorderStyle.None;
                

                txtName.TextChanged += new EventHandler(Name_TextChanged);
                txtDescription.TextChanged += new EventHandler(Description_TextChanged);
                picBox.Click += new EventHandler(ButtonChangeClick);
                picDelete.Click += new EventHandler(ButtonDeleteClick);
                txtPrice.TextChanged += TxtPrice_TextChanged;
                //btnEdit.Click += btnEdit_Click;

                // List
                lslabelName.Add(labelName);
                lsdescription.Add(description);
                lspicBox.Add(picBox);
                lspicDelete.Add(picDelete);
                lstxtName.Add(txtName);
                lstxtDes.Add(txtDescription);
                lspicEdit.Add(picEdit);
                lstxtPrice.Add(txtPrice);
                lslabelPrice.Add(labelPrice);
                if (isFood == true)
                {
                    panel_Food.Controls.Add(picBox);
                    panel_Food.Controls.Add(labelName);
                    panel_Food.Controls.Add(description);
                    panel_Food.Controls.Add(picDelete);
                    panel_Food.Controls.Add(txtName);
                    panel_Food.Controls.Add(txtDescription);
                    panel_Food.Controls.Add(labelPrice);
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
                    panel_Drink.Controls.Add(labelPrice);
                    // panel_Drink.Controls.Add(picEdit);
                }

                count++;
            }
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {
            myTextEdit txt = sender as myTextEdit;
            txt.objectText = txt.Text;
            foreach (var item in lsFoodDrink_Temp)
            {
                if (item.FoodDrinkID == txt.objectID)
                {
                    try
                    {
                        item.FoodPrice = Double.Parse(txt.Text);
                    }
                   catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex);
                    }
                }

            }
        }

        public void LoadData()
        {
            
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
            isEdit = true;
            btnEdit.Visible = false;
            btnAdd.Visible = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            
            foreach (var item in lslabelName)
                item.Visible = false;
            foreach (var item in lsdescription)
                item.Visible = false;
            //foreach (var item in lspicBox)
            //    item.Visible = false;
            foreach (var item in lslabelPrice)
                item.Visible = false;
            foreach (var item in lstxtDes)
                item.Visible = true;
            foreach (var item in lstxtName)
                item.Visible = true;
            foreach (var item in lstxtPrice)
            {
                item.Visible = true;
                MessageBox.Show("" + item.objectID);
            }
               
            foreach (var item in lspicDelete)
            {
                item.Visible = false;
                item.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form_AddFood f = new Form_AddFood(mainform);
            f.ShowDialog();
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
            bool result = false;
            foreach (var item in lsFoodDrink_Temp)
            {
                if (foodDrinkBLL.EditFoodDrink(item) == false)
                {
                    result = false;
                    MessageBox.Show("Cannot save. Please try again");
                    break;
                }
                else
                    result = true;
            }
            if (result == true)
            {
                MessageBox.Show("Saved Successfully");
                this.Hide();
                mainform.loadUCMenuEdit();
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

        private void txtSearch2_Enter(object sender, EventArgs e)
        {
            if (txtSearch2.Text == "Search...")
                txtSearch2.Text = "";

        }

        private void txtSearch2_Leave(object sender, EventArgs e)
        {
            if (txtSearch2.Text == "")
                txtSearch2.Text = "Search...";
        }
    }
}
