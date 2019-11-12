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
        public List<FoodDrink> GetListFoodDrink()
        {
            return dbContext.FoodDrinks.ToList();
        }
        public bool EditFoodDrink(FoodDrink food)
        {
            try
            {
                if (food != null)
                {

                    FoodDrink fDrink = dbContext.FoodDrinks.Where(f => f.FoodDrinkID == food.FoodDrinkID).FirstOrDefault();
                    if (fDrink == null)
                        return false;
                    fDrink.ImageURL = food.ImageURL;
                    fDrink.FoodDrinkName = food.FoodDrinkName;
                    fDrink.Description = food.Description;
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteFoodDrinkByID(int foodID)
        {
            FoodDrink fDrink = dbContext.FoodDrinks.Where(f => f.FoodDrinkID == foodID).FirstOrDefault();
            if (fDrink != null)
            {
                dbContext.FoodDrinks.Remove(fDrink);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool AddFoodDrink(FoodDrink foodDrink)
        {
            try
            {
                if (foodDrink != null)
                {
                    dbContext.FoodDrinks.Add(foodDrink);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}