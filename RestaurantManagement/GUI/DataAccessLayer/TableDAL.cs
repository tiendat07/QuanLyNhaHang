using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class TableDAL
    {
        RestaurantContextEntities dbContext;
        public TableDAL()
        {
            dbContext = new RestaurantContextEntities();
        }
        public List <Table> GetListTable()
        {
            return dbContext.Tables.ToList();
        }
    }
}
