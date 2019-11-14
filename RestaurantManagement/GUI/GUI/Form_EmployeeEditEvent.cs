using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_EmployeeEditEvent : Form
    {
        Form_Restaurant mainform;
        static Form_Restaurant _obj;
        DataGridView datagrid;
        public EmployeeBLL employeeBLL;
        public Form_EmployeeEditEvent(Form_Restaurant form, UCEmployee uCEmployee)
        {
            datagrid = uCEmployee.GetDataGridView();
            employeeBLL = new EmployeeBLL();
            mainform = form;
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainform.loadUCEmployeeEdit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            UCEmployee_Add uc = new UCEmployee_Add(mainform, datagrid);
            mainform.loadUCEmployeeAdd();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainform.loadUCEmployeeDelate();
        }
    }
}
