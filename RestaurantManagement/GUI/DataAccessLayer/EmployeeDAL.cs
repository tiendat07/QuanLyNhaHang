using DataAccessLayer;
using System;
using System.Collections.Generic;
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
        public List<Employee> GetListEmployee()
        {
            return dbContext.Employees.ToList();
        }
        public bool CheckLogin(string U, string P)
        {
            var x = dbContext.Employees.Where(n => n.Username == U && n.Password == P).Select(n => n.Username);
            return (x.Any()) ? true : false;
        }
    }
}
