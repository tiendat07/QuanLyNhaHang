using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class BookingTable
    {
        [Key, Column(Order = 0)]
        public int CustomerID { get; set; }
        [Key, Column(Order = 1)]
        public int TableID { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public DateTime ExpiredTime { get; set; }
    }
}