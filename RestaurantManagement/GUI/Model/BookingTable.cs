using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BookingTable
    {
        public string BookingTableID { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}