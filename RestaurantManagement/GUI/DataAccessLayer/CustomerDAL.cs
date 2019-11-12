using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataAccessLayer
{
    public class CustomerDAL
    {
        RestaurantContextEntities dbContext;
        public CustomerDAL()
        {
            dbContext = new RestaurantContextEntities();
        }
        public List<Customer> GetListCustomer()
        {
            return dbContext.Customers.ToList();
        }
    }
}
