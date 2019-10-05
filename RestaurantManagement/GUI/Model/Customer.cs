using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsFemale { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string CMND { get; set; }
        public List<BookingTable> BookingTables { get; set; }
        public List<Order> Orders { get; set; }
    }
}