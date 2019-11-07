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
    public partial class UCTable_Edit : UserControl
    {
        Form_Restaurant mainform;
        public UCTable_Edit(Form_Restaurant form1)
        {
            mainform = form1;
            InitializeComponent();
        }
    }
}
