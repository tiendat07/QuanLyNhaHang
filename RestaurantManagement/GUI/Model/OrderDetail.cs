using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public string x { get; set; }
        public float Price { get; set; }
    }

}