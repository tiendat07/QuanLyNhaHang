using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class UCHome : UserControl
    {
        Form_Restaurant mainform;
        int EmpID;
        public UCHome(Form_Restaurant form, int EmployeeID)
        {
            EmpID = EmployeeID;
            mainform = form;
            InitializeComponent();
        }
        
        private void btnProfile_Click(object sender, EventArgs e)
        {
            Form_Profile f = new Form_Profile(EmpID);
            f.ShowDialog();
            f.Close();
        }

        private void btnSignOut_Click_1(object sender, EventArgs e)
        {
            mainform.Hide();
            Form_Login f = new Form_Login();
            f.ShowDialog();
            f.Close();
        }
        
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            Form_ChangePassword f = new Form_ChangePassword(EmpID);
            f.ShowDialog();
        }
    }
}
