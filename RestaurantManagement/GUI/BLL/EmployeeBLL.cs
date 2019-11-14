
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
            return employeeDAL.GetListEmployeeEdit();
        }
        public bool EditEmployee(Employee e)
        {
            return employeeDAL.EditEmployee(e);
        }
        public bool AddEmployee(Employee e)
        {
            return employeeDAL.AddEmployee(e);
        }
        public bool DeleteEmployee(int ID)
        {
            return employeeDAL.DeleteEmployee(ID);
        }
    }
}
