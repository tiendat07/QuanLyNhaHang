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
            RenderChart1();
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

        public void RenderChart1()
        {
            Chart1.colorSet.Add(Color.FromArgb(255, 128, 255));
            Chart1.colorSet.Add(Color.FromArgb(128, 128, 255));
            Chart1.colorSet.Add(Color.FromArgb(128, 255, 255));
            Chart1.colorSet.Add(Color.FromArgb(128, 255, 128));
            Chart1.colorSet.Add(Color.FromArgb(255, 255, 128));
            Chart1.colorSet.Add(Color.FromArgb(255, 192, 128));
            Chart1.colorSet.Add(Color.FromArgb(255, 128, 128));
            Chart1.colorSet.Add(Color.FromArgb(188, 143, 143));

            Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
            Bunifu.DataViz.WinForms.DataPoint values = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_doughnut);

            SortedDictionary<int, float> totalall = statictisBLL.TotalAll();

            foreach (var item in totalall)
                values.addLabely("", item.Value);

            canvas.addData(values);
            Chart1.Render(canvas);
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


        private void btnStatistic1_Click(object sender, EventArgs e)
        {
            switch(cBTypeTK.SelectedIndex)
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
    }
}
