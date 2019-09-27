using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsPaid { get; set; }
        public float Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}