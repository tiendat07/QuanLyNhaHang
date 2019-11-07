using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeDAL
    {
        RestaurantContext dbContext;
        public EmployeeDAL()
        {
            dbContext = new RestaurantContext();
        }
        public List<Employee> GetListEmployee()
        {
            return dbContext.Employees.ToList();
        }
    }
}
