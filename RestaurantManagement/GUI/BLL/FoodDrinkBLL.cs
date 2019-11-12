using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BLL
{
    public class FoodDrinkBLL
    {
        FoodDrinkDAL foodDrinkDAL;
        public FoodDrinkBLL()
        {
            foodDrinkDAL = new FoodDrinkDAL();
        }
        public List<FoodDrink> GetListFoodDrink()
        {
            return foodDrinkDAL.GetListFoodDrink();
        }
        //public string GetImageFoodDrink()
        //{
        //    return foodDrinkDAL.GetImageFoodDrink();
        //}
        public bool EditFoodDrink(FoodDrink food)
        {
            return foodDrinkDAL.EditFoodDrink(food);
        }
        public bool DeleteFoodDrinkByID(int foodID)
        {
            return foodDrinkDAL.DeleteFoodDrinkByID(foodID);
        }
        public bool AddFoodDrink(FoodDrink foodDrink)
        {
            return foodDrinkDAL.AddFoodDrink(foodDrink);
        }
    }
}
