using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    class myNumericUpDown : NumericUpDown
    {
        public int objectID;
        public int ObjectID
        {
            get { return objectID; }
            set { objectID = value; }
        }
    }
}
