using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class FoodDrink
    {
        public string FoodDrinkID { get; set; }
        public string FoodDrinkName { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsFood { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}