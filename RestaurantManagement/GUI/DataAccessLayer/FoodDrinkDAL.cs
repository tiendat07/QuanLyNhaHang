using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class FoodDrinkDAL
    {
        RestaurantContextEntities dbContext;
        public FoodDrinkDAL()
        {
            dbContext = new RestaurantContextEntities();
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
