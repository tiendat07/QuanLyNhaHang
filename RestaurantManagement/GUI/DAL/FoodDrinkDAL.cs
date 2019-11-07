using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FoodDrinkDAL
    {
        RestaurantContext dbContext;
        public FoodDrinkDAL()
        {
            dbContext = new RestaurantContext();
        }
        public List <FoodDrink> GetListFoodDrink()
        {
            return dbContext.FoodDrinks.ToList();
        }
        //public string GetImageFoodDrink()
        //{
        //    return dbContext.FoodDrinks.SqlQuery("Select ImageURL from FoodDrink").FirstOrDefault<FoodDrink>().ToString();
        //}
    }
}
