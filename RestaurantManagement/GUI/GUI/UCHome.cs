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
        public UCHome(Form_Restaurant form)
        {
            mainform = form;
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            mainform.Hide();
            Form_Login f = new Form_Login();
            f.Show();
        }
    }
}
