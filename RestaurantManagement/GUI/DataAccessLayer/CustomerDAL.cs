using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;

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

        public List<Customer> Sreach(string x, int k)
        {
            if (k == 0) // cac loai ko can phan loai
            {
                return dbContext.Customers.Where(y => y.Name.StartsWith(x) ||  y.CMND.StartsWith(x)|| y.CMND.StartsWith(x)
                || SqlFunctions.StringConvert((double)y.CustomerID).TrimStart().StartsWith(x) || y.PhoneNumber.Contains(x)).ToList();
            }
            if (k == 1) //nam
            {
                return dbContext.Customers.Where(y => y.IsFemale == false).ToList();
            }
            if (k == 2)//nu
            {
                return dbContext.Customers.Where(y => y.IsFemale == true).ToList();
            }
            if (k == 3)//nam + string x
            {
                return dbContext.Customers.Where(y => y.IsFemale == false && (y.Name.StartsWith(x) || y.CMND.StartsWith(x) || y.CMND.StartsWith(x)
                || SqlFunctions.StringConvert((double)y.CustomerID).TrimStart().StartsWith(x) || y.PhoneNumber.Contains(x))).ToList();
            }
            if (k == 4)//nu + string x
            {
                return dbContext.Customers.Where(y => y.IsFemale == true && (y.Name.StartsWith(x) || y.CMND.StartsWith(x) || y.CMND.StartsWith(x)
                || SqlFunctions.StringConvert((double)y.CustomerID).TrimStart().StartsWith(x) || y.PhoneNumber.Contains(x))).ToList();
            }
            return dbContext.Customers.ToList();

        }
        public List<Customer> LoadRecord(int page, int recordNum)
        {
            List<Customer> result = new List<Customer>();
            result = dbContext.Customers.Where(e => e.Status == 1).OrderBy(s => s.CustomerID).Skip((page - 1) * recordNum).Take(recordNum).ToList(); //bỏ qua những cái đã load chỉ lấy phần cần lấy

            return result;
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
        public int GetCustomerID (Customer c)
        {
            return dbContext.Customers.Where(x => x.CustomerID == c.CustomerID).Select(y => y.CustomerID).FirstOrDefault();
        }
    }
}
