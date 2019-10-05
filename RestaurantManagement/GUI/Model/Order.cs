using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public bool IsPaid { get; set; }
        [Required]
        public float Total { get; set; }
        //[Required] //?
        public List<OrderDetail> OrderDetails { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public int TableID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
    }
}