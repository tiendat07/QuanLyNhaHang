using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderDAL
    {
        RestaurantContextEntities dbContext;
        public OrderDAL()
        {
            dbContext = new RestaurantContextEntities();
        }
        public bool AddOrder(Order o, List<OrderDetail> orderDetails)
        {
            using (DbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var hoaDonTam = dbContext.Orders.Add(new Order()
                    {
                        OrderDate = o.OrderDate,
                        IsPaid = false,
                        Total = o.Total,
                        CustomerID = o.CustomerID,
                        TableID = o.TableID,
                        EmployeeID = o.EmployeeID,
                        OrderDetails = orderDetails
                    });
                    dbContext.SaveChanges();
                    foreach (OrderDetail chiTiet in o.OrderDetails)
                    {
                        chiTiet.OrderID = hoaDonTam.OrderID;
                        dbContext.OrderDetails.Add(chiTiet);

                    }
                    dbContext.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return false;
                }
            }

        }
        public bool SetPaid(int ID)
        {
            if (ID > 0)
            {
                Order x = dbContext.Orders.Where(o => o.TableID == ID).FirstOrDefault();
                if (x != null)
                {
                    x.IsPaid = true;
                    dbContext.SaveChanges();
                    return true;

                }
                return false;
            }
            else
                return false;
        }
    }
}
