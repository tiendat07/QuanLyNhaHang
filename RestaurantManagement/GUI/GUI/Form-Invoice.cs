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
namespace GUI
{
    public partial class Form_Invoice : Form
    {
        public Form_Invoice()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        public void PrintInvoice(string EmpName, Order order, List<OrderDetail> data)
        {
            InvoiceReport report = new InvoiceReport();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;
            report.InitData(order.OrderID, order.TableID, order.OrderDate, EmpName, data);
            documentViewer1.DocumentSource = report;
            report.CreateDocument();

        }
    }
}
