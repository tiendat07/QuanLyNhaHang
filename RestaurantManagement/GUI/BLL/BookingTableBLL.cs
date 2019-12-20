using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BLL
{
    public class BookingTableBLL
    {
        BookingTableDAL bookingTableDAL;
        public BookingTableBLL()
        {
            bookingTableDAL = new BookingTableDAL();
        }
        public bool AddBookingTable(BookingTable bookingTable)
        {
            return bookingTableDAL.AddBookingTable(bookingTable);
        }
        public int FindCustomerIDByTableID(int TableID)
        {
            return bookingTableDAL.FindCustomerIDByTableID(TableID);
        }
    }
}
