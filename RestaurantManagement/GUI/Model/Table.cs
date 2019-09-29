using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class Table
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TableID { get; set; }
        [Required]
        public string TableName { get; set; }
        [Required]
        public int Status { get; set; }
        public static Hashtable Statuses = new Hashtable()
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