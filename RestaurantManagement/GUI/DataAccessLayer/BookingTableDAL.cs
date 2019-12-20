using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingTableDAL
    {
        RestaurantContextEntities dbContext;
        public BookingTableDAL()
        {
            dbContext = new RestaurantContextEntities();
        }
        public bool AddBookingTable(BookingTable bookingTable)
        {
            if (bookingTable != null)
            {
                dbContext.BookingTables.Add(bookingTable);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public int FindCustomerIDByTableID (int TableID)
        {
            try
            {
                if (TableID > 0)
                {
                    return dbContext.BookingTables.Where(t => t.TableID == TableID).Select(t => t.CustomerID).FirstOrDefault();
                }
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
