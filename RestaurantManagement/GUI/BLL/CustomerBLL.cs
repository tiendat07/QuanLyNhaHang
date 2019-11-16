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
    }
}
