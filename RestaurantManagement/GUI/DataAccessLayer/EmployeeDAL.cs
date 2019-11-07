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
    }
}
