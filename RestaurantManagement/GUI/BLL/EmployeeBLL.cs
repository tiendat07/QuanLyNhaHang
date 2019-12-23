
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


        public bool CheckLogin(string U, string P)
        {
            return employeeDAL.CheckLogin(U, P);

        }

        public bool AddEmployee(Employee e)
        {
            return employeeDAL.AddEmployee(e);

        }
        public bool DeleteEmployee(int ID)
        {
            return employeeDAL.DeleteEmployee(ID);
        }
        public bool CheckAdmin(string username)
        {
            return employeeDAL.CheckAdmin(username);
        }

        public int GetEmployeeID(string username)
        {
            return employeeDAL.GetEmployeeID(username);
        }

        public Employee FindEmployee(int id)
        {
            return employeeDAL.FindEmployee(id);
        }

        public List<Employee> LoadRecord(int page, int recordNum)
        {
            return employeeDAL.LoadRecord(page, recordNum);
        }

        public List<Employee> Sreach(string x, int k, int page, int recordNum)
        {
            return employeeDAL.Sreach(x, k,page,recordNum);
        }

        public bool CheckPassword(int EmployeeID, string Password)
        {
            return employeeDAL.CheckPassword(EmployeeID, Password);
        }
        public bool IsDuplicated(string username)
        {
            return employeeDAL.IsDuplicated(username);
        }
    }
}
