using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderDetailDAL
    {
        RestaurantContextEntities dbContext;
        public OrderDetailDAL()
        {
            dbContext = new RestaurantContextEntities();
        }
        public List<OrderDetail> GetListOrderDetails ()
        {
            return dbContext.OrderDetails.ToList();
        }
        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                if (orderDetail != null)
                {
                    dbContext.OrderDetails.Add(orderDetail);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
