using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;

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

        public bool AddCustomer(Customer e)
        {
            try
            {
                if(e!=null)
                {
                    dbContext.Customers.Add(e);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool EditCustomer(Customer e)
        {
            try
            {
                if(e!=null)
                {
                    Customer eTmp = dbContext.Customers.Where(d => d.CustomerID == e.CustomerID).FirstOrDefault();
                    if (eTmp == null)
                        return false;
                    eTmp.CustomerID = e.CustomerID;
                    eTmp.Name = e.Name;
                    eTmp.IsFemale = e.IsFemale;
                    eTmp.PhoneNumber = e.PhoneNumber;
                    eTmp.CMND = e.CMND;
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

        public bool DeleteCustomer(int ID)
        {
            Customer e = dbContext.Customers.Where(d => d.CustomerID == ID).FirstOrDefault();
            try
            {
                if(e!=null)
                {
                    dbContext.Customers.Remove(e);
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
    }
}
