using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
            List<Employee> result = new List<Employee>();
            foreach (Employee e in dbContext.Employees.ToList())
            {
                if (e.Status == 1)
                    result.Add(e);
            }
            return result;
        }

        public bool CheckLogin(string U, string P)
        {
            if (U != null && P != null)
            {
                try
                {
                    string storedHash = dbContext.Employees.Where(u => u.Username == U).Select(y => y.Password).First();
                    if (storedHash != null)
                        return BCrypt.Net.BCrypt.Verify(P, storedHash);
                }
                catch(Exception e)
                {
                    return false;
                }
                
            }
            return false;
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
                if (ID >= 0 && e != null)
                {
                    e.Status = 0; //0: nghi - 1:dang lam 
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

        public int GetEmployeeID (string username)

        {
            var x = dbContext.Employees.Where(n => n.Username == username).FirstOrDefault();
            return x.EmployeeID;
        }

        public Employee FindEmployee (int id)
        {
            return dbContext.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
        }
        public List<Employee> LoadRecord(int page, int recordNum)
        { 
            List<Employee> result = new List<Employee>();

            result = dbContext.Employees.Where(e => e.Status == 1).OrderBy(s=> s.EmployeeID).Skip((page - 1) * recordNum).Take(recordNum).ToList(); //bỏ qua những cái đã load chỉ lấy phần cần lấy
            
            return result;
        }
       
        public List<Employee> Sreach(string x,int k,int page, int recordNum)
        {
            if(k==0) // cac loai ko can phan loai
            {
                return dbContext.Employees.Where(y => y.Name.Contains(x)|| y.Address.StartsWith(x)|| y.CMND.StartsWith(x) 
                || EntityFunctions.TruncateTime(y.DateOfBirth).ToString().Contains(x)|| y.Email.StartsWith(x) 
                || SqlFunctions.StringConvert((double)y.EmployeeID).TrimStart().StartsWith(x) || y.PhoneNumber.Contains(x))
                .OrderBy(s => s.EmployeeID).Skip((page - 1) * recordNum).Take(recordNum).ToList();
                
            }
            if(k==1) //nam
            {
                return dbContext.Employees.Where(y => y.IsFemale == false).ToList();
            }
            if (k == 2)//nu
            {
                return dbContext.Employees.Where(y => y.IsFemale == true).ToList();
            }
            if (k == 3) //admin
            {
                return dbContext.Employees.Where(y => y.IsAdmin == true).ToList();
            }
            if(k==4) //nhan vien
            {
                return dbContext.Employees.Where(y => y.IsAdmin == false).ToList();
            }
            if(k==5)//nam + string x
            {
                return dbContext.Employees.Where(y => y.IsFemale==false && (y.Name.Contains(x) || y.Address.StartsWith(x) 
                || y.CMND.StartsWith(x) || y.Email.StartsWith(x) || y.PhoneNumber.Contains(x)
                || EntityFunctions.TruncateTime(y.DateOfBirth).ToString().Contains(x) 
                || SqlFunctions.StringConvert((double)y.EmployeeID).TrimStart().StartsWith(x)))
                .OrderBy(s => s.EmployeeID).Skip((page - 1) * recordNum).Take(recordNum).ToList();
            }
            if (k == 6)//nu + string x
            {
                return dbContext.Employees.Where(y => y.IsFemale == true && (y.Name.Contains(x) || y.Address.StartsWith(x)
                || y.CMND.StartsWith(x) || y.Email.StartsWith(x) || y.PhoneNumber.Contains(x)
                || EntityFunctions.TruncateTime(y.DateOfBirth).ToString().Contains(x)
                || SqlFunctions.StringConvert((double)y.EmployeeID).TrimStart().StartsWith(x)))
                .OrderBy(s => s.EmployeeID).Skip((page - 1) * recordNum).Take(recordNum).ToList();
            }
            if (k == 7)//admin + string x
            {
                return dbContext.Employees.Where(y => y.IsAdmin == true && (y.Name.Contains(x) || y.Address.StartsWith(x)
                || y.CMND.StartsWith(x) || y.Email.StartsWith(x) || y.PhoneNumber.Contains(x)
                || EntityFunctions.TruncateTime(y.DateOfBirth).ToString().Contains(x)
                || SqlFunctions.StringConvert((double)y.EmployeeID).TrimStart().StartsWith(x)))
                .OrderBy(s => s.EmployeeID).Skip((page - 1) * recordNum).Take(recordNum).ToList();
            }
            if (k == 8)//employee + string x
            {
                return dbContext.Employees.Where(y => y.IsAdmin == false && (y.Name.Contains(x) || y.Address.StartsWith(x)
                || y.CMND.StartsWith(x) || y.Email.StartsWith(x) || y.PhoneNumber.Contains(x)
                || EntityFunctions.TruncateTime(y.DateOfBirth).ToString().Contains(x)
                || SqlFunctions.StringConvert((double)y.EmployeeID).TrimStart().StartsWith(x)))
                .OrderBy(s => s.EmployeeID).Skip((page - 1) * recordNum).Take(recordNum).ToList();
            }
            return dbContext.Employees.ToList();

        }
        public bool CheckPassword(int EmployeeID, string Password)
        {
            if (Password != null && EmployeeID > 0)
            {
                try
                {
                    string storedHash = dbContext.Employees.Where(e => e.EmployeeID == EmployeeID).Select(e => e.Password).First();
                    if (storedHash != null)
                        return BCrypt.Net.BCrypt.Verify(Password, storedHash);
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
