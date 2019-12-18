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
    public partial class UCStatistic : UserControl
    {
        public StatictisBLL statictisBLL;
        public UCStatistic()
        {
            statictisBLL = new StatictisBLL();
            InitializeComponent();
            Clear();
            dtpDen.CustomFormat = "dd-MM-yyyy";
            dtpTu.CustomFormat = "dd-MM-yyyy";
            cbTop.SelectedItem = "Most Favorite";
            lbTotal.Text = statictisBLL.GetTotal().ToString();
            cBTypeTK.SelectedItem = "Day";
            Statistic();
        }

        void Clear()
        {
            lbTuNgay.Visible = false;
            lbTuThang.Visible = false;
            lbTuNam.Visible = false;
            lbDenNgay.Visible = false;
            lbDenThang.Visible = false;
            lbDenNam.Visible = false;
            dtpDen.Visible = false;
            dtpTu.Visible = false;
            cBtuThang.Visible = false;
            cBtuNamofThang.Visible = false;
            cBtuNam.Visible = false;
            cBdenThang.Visible = false;
            cbdenNamofThang.Visible = false;
            cBdenNam.Visible = false;

            dtpTu.Value = DateTime.Today;
            dtpDen.Value = DateTime.Today.AddDays(1);
            dtpDen.CustomFormat = "dd-MM-yyyy";
            dtpTu.CustomFormat = "dd-MM-yyyy";
            cBtuThang.Text ="";
            cBtuNamofThang.Text ="" ;
            cBtuNam.Text = "";
            cBdenThang.Text = "";
            cbdenNamofThang.Text = "";
            cBdenNam.Text = "";
            cBTypeTK.Text = "-Select-";
        }
        private void cBTypeTK_TextChanged(object sender, EventArgs e)
        {
            if(cBTypeTK.Text=="Day")
            {
                lbTuNgay.Visible = true;
                lbDenNgay.Visible = true;
                dtpDen.Visible = true;
                dtpTu.Visible = true;

                lbTuThang.Visible = false;
                lbTuNam.Visible = false;
                lbDenThang.Visible = false;
                lbDenNam.Visible = false;

                cBtuThang.Visible = false;
                cBtuNamofThang.Visible = false;
                cBtuNam.Visible = false;
                cBdenThang.Visible = false;
                cbdenNamofThang.Visible = false;
                cBdenNam.Visible = false;
            }
            if(cBTypeTK.Text=="Month")
            {
                lbTuThang.Visible = true;
                lbDenThang.Visible = true;
                cBtuThang.Visible = true;
                cBdenThang.Visible = true;
                cbdenNamofThang.Visible = true;
                cBtuNamofThang.Visible = true;

                lbTuNgay.Visible = false;
                lbDenNgay.Visible = false;
                dtpDen.Visible = false;
                dtpTu.Visible = false;

                cBtuNam.Visible = false;
                cBdenNam.Visible = false;
                lbTuNam.Visible = false;
                lbDenNam.Visible = false;
            }
            if(cBTypeTK.Text=="Year")
            {
                lbTuNam.Visible = true;
                lbDenNam.Visible = true;
                cBtuNam.Visible = true;
                cBdenNam.Visible = true;

                lbTuNgay.Visible = false;
                lbDenNgay.Visible = false;
                dtpDen.Visible = false;
                dtpTu.Visible = false;

                lbTuThang.Visible = false;
                lbDenThang.Visible = false;
                cBtuThang.Visible = false;
                cBtuNamofThang.Visible = false;
                cBdenThang.Visible = false;
                cbdenNamofThang.Visible = false;
            }
        }

        private void txtClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void RenderChart1(bool isTopMost)
        {
            Chart1.colorSet.Add(Color.FromArgb(55, 101, 177));
            Chart1.colorSet.Add(Color.FromArgb(87, 151, 255));
            Chart1.colorSet.Add(Color.FromArgb(17, 177, 193));
            Chart1.colorSet.Add(Color.FromArgb(241, 77, 255));
            Chart1.colorSet.Add(Color.FromArgb(148, 38, 131));
            Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
            Bunifu.DataViz.WinForms.DataPoint values = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_doughnut);

            SortedDictionary<int, float> totalall = statictisBLL.TotalAll(isTopMost);

            foreach (var item in totalall)
                values.addLabely("", item.Value);
            
            canvas.addData(values);
            Chart1.Render(canvas);
            LoadLegend(totalall);
        }
        public void LoadLegend(SortedDictionary<int, float> totalall)
        {
            FoodDrinkBLL foodDrinkBLL = new FoodDrinkBLL();
            Dictionary<string, float> lsFoodName = new Dictionary<string, float>();
            foreach (var item in totalall)
            {
                string name = foodDrinkBLL.GetFoodDrinkName(item.Key);
                lsFoodName[name] = item.Value;
            }

            int count = 1;
            int x = 0, y = 0, z = 0;
            int pX = 3, pY =5;
            foreach (var item in lsFoodName)
            {
                if (count > 5)
                    break;
                Bunifu.Framework.UI.BunifuCheckbox cb1 = new Bunifu.Framework.UI.BunifuCheckbox();
                if (count == 1)
                {
                    //55, 101, 177
                    x = 55; y = 101; z = 177;

                }
                else if (count == 2)
                {
                    //87, 151, 255
                    x = 87; y = 151; z = 255;
                }
                else if (count == 3)
                {
                    //17, 177, 193
                    x = 17; y = 177; z = 193;
                }
                else if (count == 4)
                {
                    //241, 77, 255
                    x = 241; y = 77; z = 255;
                }
                else
                {
                    //148, 38, 131
                    x = 148; y = 38; z = 131;
                }
                count++;
                cb1.BackColor = Color.FromArgb(x, y, z);
                cb1.CheckedOnColor = Color.FromArgb(x, y, z);
                cb1.ChechedOffColor = Color.FromArgb(x, y, z);
                cb1.Size = new Size(20, 20);
                cb1.ForeColor = Color.FromArgb(x, y, z);
                cb1.Location = new Point(pX, pY);

                Label lName = new Label();
                lName.Text = item.Key;
                lName.Location = new Point(pX + 26, pY);



                Label lPercent = new Label();
                lPercent.Text = item.Value.ToString();
                lPercent.AutoSize = false;
                lPercent.Size = new Size(80, 23);
                lPercent.Location = new Point(pX + 132, pY);


                panelLegend.Controls.Add(cb1);
                panelLegend.Controls.Add(lName);
                panelLegend.Controls.Add(lPercent);
                
                pY += 26;
            }



        }
        public void RenderChart2_Date()
        {
            Chart2.colorSet.Add(Color.FromArgb(137, 182, 255));
            Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
            Bunifu.DataViz.WinForms.DataPoint values = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_splineArea);

            DateTime TuNgay = Convert.ToDateTime(dtpTu.Value).Date;
            DateTime DenNgay = Convert.ToDateTime(dtpDen.Value).Date.AddDays(1).AddTicks(-1);

            SortedDictionary<string, float> totalofdate =statictisBLL.TotalofDate(TuNgay, DenNgay);

            foreach (var item in totalofdate)
                values.addLabely(item.Key, item.Value);

            canvas.addData(values);
            Chart2.Render(canvas);
        }

        public void RenderChart2_Month()
        {
            Chart2.colorSet.Add(Color.FromArgb(137, 182, 255));
            Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
            Bunifu.DataViz.WinForms.DataPoint values = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_splineArea);
            
            
            int month1 = Convert.ToInt32(cBtuThang.SelectedItem);
            int year1 = Convert.ToInt32(cBtuNamofThang.SelectedItem);
            int month2 = Convert.ToInt32(cBdenThang.SelectedItem);
            int year2 = Convert.ToInt32(cbdenNamofThang.SelectedItem);

            SortedDictionary<string, float> totalofmonth = statictisBLL.TotalofMonth(month1,year1,month2,year2);

            foreach (var item in totalofmonth)
                values.addLabely(item.Key, item.Value);
            canvas.addData(values);
            Chart2.Render(canvas);
        }

        public void RenderChart2_Year()
        {
            Chart2.colorSet.Add(Color.FromArgb(137, 182, 255));
            Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
            Bunifu.DataViz.WinForms.DataPoint values = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_splineArea);


            int year1 = Convert.ToInt32(cBtuNam.SelectedItem);
            int year2 = Convert.ToInt32(cBdenNam.SelectedItem);

            SortedDictionary<int, float> totalofyear = statictisBLL.TotalofYear(year1,year2);

            foreach (var item in totalofyear)
                values.addLabely(item.Key.ToString(), item.Value);
            canvas.addData(values);
            Chart2.Render(canvas);
        }
        bool month1 = false;
        bool month2 = false;
        bool year1 = false;
        bool year2 = false;

        public void Statistic ()
        {

            switch (cBTypeTK.SelectedIndex)
            {
                case 0://ngay
                    {
                        if (dtpTu.Value > dtpDen.Value)
                        {
                            MessageBox.Show("Thời gian bắt đầu phải trước thời gian kết thúc");
                            break;
                        }
                        RenderChart2_Date();
                        break;
                    }
                case 1://thang
                    {
                        month1 = !String.IsNullOrEmpty(cBtuThang.Text);
                        month2 = !String.IsNullOrEmpty(cBdenThang.Text);
                        year1 = !String.IsNullOrEmpty(cBtuNamofThang.Text);
                        year2 = !String.IsNullOrEmpty(cbdenNamofThang.Text);
                        if (month1 == true && month2 == true && year1 == true && year2 == true)
                        {
                            int month1 = Convert.ToInt32(cBtuThang.SelectedItem);
                            int year1 = Convert.ToInt32(cBtuNamofThang.SelectedItem);
                            int month2 = Convert.ToInt32(cBdenThang.SelectedItem);
                            int year2 = Convert.ToInt32(cbdenNamofThang.SelectedItem);
                            if (year1 > year2)
                            {
                                MessageBox.Show("Thời gian bắt đầu phải trước thời gian kết thúc");
                                break;
                            }
                            if (year1 == year2 && month1 > month2)
                            {
                                MessageBox.Show("Thời gian bắt đầu phải trước thời gian kết thúc");
                                break;
                            }
                            RenderChart2_Month();
                        }
                        break;
                    }
                case 2:
                    {
                        year1 = !String.IsNullOrEmpty(cBtuNam.Text);
                        year2 = !String.IsNullOrEmpty(cBdenNam.Text);
                        if (year1 == true && year2 == true)
                        {
                            int year1 = Convert.ToInt32(cBtuNam.SelectedItem);
                            int year2 = Convert.ToInt32(cBdenNam.SelectedItem);
                            if (year1 > year2)
                            {
                                MessageBox.Show("Thời gian bắt đầu phải trước thời gian kết thúc");
                                break;
                            }
                            RenderChart2_Year();
                        }
                        break;
                    }
            }
        }
        private void btnStatistic1_Click(object sender, EventArgs e)
        {
            Statistic();
        }
        
        
        private void cbTop_TextChanged(object sender, EventArgs e)
        {
            panelLegend.Controls.Clear();
            if (cbTop.SelectedItem.ToString() == "Most Favorite")
            {
                RenderChart1(true);
            }
            if (cbTop.SelectedItem.ToString() == "Least Favorite")
                RenderChart1(false);
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
