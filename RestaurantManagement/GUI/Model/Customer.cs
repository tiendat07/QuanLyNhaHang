using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Customer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string CMND { get; set; }
        public List<BookingTable> BookingTables { get; set; }
        public List<Order> Orders { get; set; }
    }
}