using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    class myButtonEdit : PictureBox
    {
        public int objectID;
        public int ObjectID
        {
             get { return objectID; }
             set { objectID = value; }
        }
    }
    class myButton : Button
    {
        public myButton()
        {
            SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
        }
        public int objectID;
        public int ObjectID
        {
            get { return objectID; }
            set { objectID = value; }
        }
    }
}
