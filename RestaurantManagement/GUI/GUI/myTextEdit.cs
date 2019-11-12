using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    class myTextEdit : TextBox
    {
        public int objectID;
        public string objectText;
        public int ObjectID
        {
            get { return objectID; }
            set { objectID = value; }
        }
        public string ObjectText
        {
            get { return objectText; }
            set { objectText = value; }
        }
    }
}
