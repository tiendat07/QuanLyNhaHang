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
    public partial class UCCustomer2 : UserControl
    {
        Form_Restaurant mainform;
        public CustomerBLL customerBLL;
        public UCCustomer2(Form_Restaurant form)
        {
            customerBLL = new CustomerBLL();
            mainform = form;
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            
        }
    }
}
