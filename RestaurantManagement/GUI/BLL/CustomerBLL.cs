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
        public Customer SearchCustomerByName(string name)
        {
            return customerDAL.SearchCustomerByName(name);
        }
        public List<string> Name_SearchCustomerByName(string name)
        {
            return customerDAL.Name_SearchCustomerByName(name);
        }
        public bool AddCustomer (Customer customer )
        {
            return customerDAL.AddCustomer(customer);
        }
        public int GetCustomerID(Customer c)
        {
            return customerDAL.GetCustomerID(c);
        }
    }
}
