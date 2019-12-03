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
    }
}
