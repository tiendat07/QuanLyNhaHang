using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DataAccessLayer;
using System.Collections.Generic;

namespace GUI
{
    public partial class InvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public InvoiceReport()
        {
            InitializeComponent();
        }
        public void InitData (int orderID, int tableID, DateTime orderDate, string employeeName, List <OrderDetail> data)
        {
            pOrderID.Value = orderID;
            pTableID.Value = tableID;
            pDate.Value = orderDate;
            pEmployeeName.Value = employeeName;
            objectDataSource1.DataSource = data;
        }
    }
}
