using DataAccessLayer;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeDAL
    {
        RestaurantContextEntities dbContext;
        
        
        public EmployeeDAL()
        {
            dbContext = new RestaurantContextEntities();
        }

        

        public List<Employee> GetListEmployeeEdit()
        {
            return dbContext.Employees.ToList();
        }

        public bool CheckLogin(string U, string P)
        {
            var x = dbContext.Employees.Where(n => n.Username == U && n.Password == P).Select(n => n.Username);
            return (x.Any()) ? true : false;
        }


        public bool AddEmployee(Employee e)
        {
            try
            {
                if (e != null)
                {
                    dbContext.Employees.Add(e);
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

        public bool EditEmployee(Employee e)
        {
            try
            {
                if(e!=null)
                {
                    Employee eTmp = dbContext.Employees.Where(d => d.EmployeeID == e.EmployeeID).FirstOrDefault();
                    if (eTmp == null)
                        return false;
                    eTmp.EmployeeID = e.EmployeeID;
                    eTmp.Name = e.Name;
                    eTmp.CMND = e.CMND;
                    eTmp.DateOfBirth = e.DateOfBirth;
                    eTmp.Email = e.Email;
                    eTmp.Address = e.Address;
                    eTmp.IsFemale = e.IsFemale;
                    eTmp.IsAdmin = e.IsAdmin;
                    eTmp.PhoneNumber = e.PhoneNumber;
                    eTmp.Password = e.Password;
                    eTmp.Username = e.Username;
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

        public bool DeleteEmployee(int ID)
        {
            Employee e = dbContext.Employees.Where(d => d.EmployeeID == ID).FirstOrDefault();
            try
            {
                if (e != null)
                {
                    dbContext.Employees.Remove(e);
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

        public bool CheckAdmin(string username)
        {
            var x = dbContext.Employees.Where(n => n.Username == username && n.IsAdmin == true).ToList();
            return (x.Any()) ? true : false;
        }
        public int GetEmployeeID(string username)
        {
            var x = dbContext.Employees.Where(n => n.Username == username).FirstOrDefault();
            return x.EmployeeID;
        }


    }
}
