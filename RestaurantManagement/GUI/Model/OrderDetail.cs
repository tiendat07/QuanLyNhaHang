using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class OrderDetail
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int OrderDetailID { get; set; }
        [Key, Column(Order = 0)]
        public int OrderID { get; set; }
        [Key, Column(Order = 1)]
        public int FoodDrinkID { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Note { get; set; }
        [Required]
        public float Price { get; set; }

    }

}