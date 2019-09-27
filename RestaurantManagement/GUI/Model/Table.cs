using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Model
{
    public class Table
    {
        public string TableID { get; set; }
        public int status { get; set; }
        public static Hashtable statuses = new Hashtable()
        {
            {
                "Empty", 0
            },
            {
                "Ordered", 1
            },
            {
                "Seated", 2
            }
        };
        public List<BookingTable> BookingTables { get; set; }
        public List<Order> Orders { get; set; }
    }
}