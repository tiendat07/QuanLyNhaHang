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

namespace GUI
{
    public partial class UCEmployeeEvenEdit : UserControl
    {
        Form_Restaurant mainform;
        static Form_Restaurant _obj;
        DataGridView datagrid;
        public EmployeeBLL employeeBLL;
        public UCEmployeeEvenEdit(Form_Restaurant form, UCEmployee uCEmployee)
        {
            datagrid = uCEmployee.GetDataGridView();
            employeeBLL = new EmployeeBLL();
            mainform = form;
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCEmployee_Add uc = new UCEmployee_Add(mainform, datagrid);
            mainform.loadUCEmployeeAdd();
        }

        private void img_Close_Click(object sender, EventArgs e)
        {
            mainform.Close();
        }

        
    }
}
