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
            if (fDrink != null && foodID >=0)
            {
                fDrink.IsAvailable = false;
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
        public string GetFoodDrinkName(int FoodID)
        {
            try
            {
                if (FoodID > 0)
                {
                    var x = dbContext.FoodDrinks.Where(f => f.FoodDrinkID == FoodID).FirstOrDefault();
                    return x.FoodDrinkName;
                }
                return null;
            }
           catch (Exception ex)
            {
                return null;
            }
        }
        public double GetFoodPrice(int FoodID)
        {
            try
            {
                if (FoodID > 0)
                {
                    var x = dbContext.FoodDrinks.Where(f => f.FoodDrinkID == FoodID).FirstOrDefault();
                    return Convert.ToDouble(x.FoodPrice);
                }
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
            
        }
        public List<FoodDrink> Search(string x, int k)
        {
            try
            {
                if (k == 0)
                {
                    // Food
                    if (x != null)
                    {
                        var result = dbContext.FoodDrinks.Where(f => f.IsFood == true && f.FoodDrinkName.StartsWith(x)).ToList();
                        return result;
                    }
                    return dbContext.FoodDrinks.Where(f => f.IsFood == true).ToList();
                }
                if (k == 1)
                {
                    // Drink
                    if (x != null)
                    {
                        var result = dbContext.FoodDrinks.Where(f => f.IsFood == false && f.FoodDrinkName.StartsWith(x)).ToList();
                        return result;
                    }
                    return dbContext.FoodDrinks.Where(f => f.IsFood == false).ToList();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}