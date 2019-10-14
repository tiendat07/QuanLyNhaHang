using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Model;
namespace BLL
{
    public class TableBLL
    {
        TableDAL tableDAL;
        public TableBLL()
        {
            tableDAL = new TableDAL();
        }
        public List<Table> GetListTable()
        {
            return tableDAL.GetListTable();
        }
    }
}
