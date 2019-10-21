using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class FoodDrinkBLL
    {
        FoodDrinkDAL foodDrinkDAL;
        public FoodDrinkBLL()
        {
            foodDrinkDAL = new FoodDrinkDAL();
        }
        public List <FoodDrink> GetListFoodDrink()
        {
            return foodDrinkDAL.GetListFoodDrink();
        }
        //public string GetImageFoodDrink()
        //{
        //    return foodDrinkDAL.GetImageFoodDrink();
        //}
    }
}
