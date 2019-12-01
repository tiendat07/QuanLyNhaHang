using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public Customer SearchCustomerByName(string name)
        {
            // Trả về ds nếu có người có tên giống nhau
            return dbContext.Customers.Where(c => c.Name == name).FirstOrDefault();
        }
        public List<string> Name_SearchCustomerByName(string name)
        {
            // Trả về ds nếu có người có tên giống nhau

            return dbContext.Customers.Where(x => x.Name.StartsWith(name))
            .Select(c => c.Name).ToList();
            
        }
        
        public bool AddCustomer (Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    dbContext.Customers.Add(customer);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        public int GetCustomerID (Customer c)
        {
            return dbContext.Customers.Where(x => x.CustomerID == c.CustomerID).Select(y => y.CustomerID).FirstOrDefault();
            
        }
    }
}
