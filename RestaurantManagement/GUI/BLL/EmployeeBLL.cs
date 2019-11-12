
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BLL
{
    public class EmployeeBLL
    {
        EmployeeDAL employeeDAL;
        public EmployeeBLL()
        {
            employeeDAL = new EmployeeDAL();
        }
        public List<Employee> GetListEmployee()
        {
            return employeeDAL.GetListEmployee();
        }
        public bool CheckLogin(string U, string P)
        {
            return employeeDAL.CheckLogin(U, P);
        }
    }
}
