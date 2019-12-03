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

namespace GUI
{
    public partial class Form_CustomerEditEvent : Form
    {
        Form_Restaurant mainform;
        static Form_Restaurant _obj;
        DataGridView datagrid;
        public CustomerBLL customerBLL;
        public Form_CustomerEditEvent(Form_Restaurant form, UCCustomer uCCustomer)
        {
            datagrid = uCCustomer.GetDataGridView();
            customerBLL = new CustomerBLL();
            mainform = form;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            UCCustomer_Add uc = new UCCustomer_Add(mainform, datagrid);
            mainform.loadUCCustomer_Add();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            

        }
    }
}
