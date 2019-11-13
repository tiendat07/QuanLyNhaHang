using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BLL
{
    public class OrderBLL
    {
        OrderDAL orderDAL;
        public OrderBLL()
        {
            orderDAL = new OrderDAL();
        }
        public bool AddOrder(Order o, List<OrderDetail> orderDetails)
        {
            return orderDAL.AddOrder(o, orderDetails);
        }
        public bool SetPaid(int ID)
        {
            return orderDAL.SetPaid(ID);
        }
    }
}
