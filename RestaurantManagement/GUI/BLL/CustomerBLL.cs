using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BLL
{
    public class CustomerBLL
    {
        CustomerDAL customerDAL;
        public CustomerBLL()
        {
            customerDAL = new CustomerDAL();
        }

        public List<Customer> GetListCustomer()
        {
            return customerDAL.GetListCustomer();
        }

        public bool EditCustomer(Customer e)
        {
            return customerDAL.EditCustomer(e);
        }

        public bool AddCustomer(Customer e)
        {
            return customerDAL.AddCustomer(e);
        }

        public bool DeleteCustomer(int ID)
        {
            return customerDAL.DeleteCustomer(ID);
        }
        /*
        public int GetCustomerID(string username)
        {
            return customerDAL.GetCustomerID(username); 
        }
        */
    }
}
