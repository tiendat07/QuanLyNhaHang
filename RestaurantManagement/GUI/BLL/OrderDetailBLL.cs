using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BLL
{
    public class OrderDetailBLL
    {
        OrderDetailDAL orderDetailDAL;
        public OrderDetailBLL()
        {
            orderDetailDAL = new OrderDetailDAL();
        }
        public List<OrderDetail> GetListOrderDetails()
        {
            return orderDetailDAL.GetListOrderDetails();
        }
        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            return orderDetailDAL.AddOrderDetail(orderDetail);
        }
    }
}
