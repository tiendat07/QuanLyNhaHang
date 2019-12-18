using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StatisticDAL
    {
        RestaurantContextEntities dbContext;

        public StatisticDAL()
        {
            dbContext = new RestaurantContextEntities();
        }

        public SortedDictionary<string, float> TotalofDate(DateTime date1,DateTime date2)
        {
            date1 = date1.Date;
            date2 = date2.Date.AddDays(1).AddTicks(-1);

            SortedDictionary<string, float> result = new SortedDictionary<string, float>();

            var lsCTHD = dbContext.Orders
                                .Where(o => o.OrderDate >= date1 && o.OrderDate <= date2&&o.IsPaid==true)
                                .GroupBy(o1 => new { o1.OrderDate })
                                .Select(o2 => new { Key = o2.Key, Total = o2.Sum(o => o.Total) });

            foreach(var ct in lsCTHD)
            {
                string dateTime = Convert.ToDateTime(ct.Key.OrderDate).ToString("dd-MM-yy");
                result[dateTime] = ct.Total;
            }

            for (DateTime date=date1;date<=date2;date=date2.AddDays(1))
            {
                string dateTime = date.ToString("dd-MM-yy");
                if(!result.ContainsKey(dateTime))
                {
                    result[dateTime] = 0;
                }
            }

            return result;
        }

        public SortedDictionary<string, float> TotalofMonth(int month1,int year1,int month2, int year2 )
        {
            DateTime date1 = new DateTime(year1, month1, 1);
            int LastDay2 = DateTime.DaysInMonth(year2, month2);
            DateTime date2 = new DateTime(year2, month2, LastDay2);

            SortedDictionary<string, float> result = new SortedDictionary<string, float>();

            var lsCTHD = dbContext.Orders
                                .Where(o => o.OrderDate >= date1 && o.OrderDate <= date2&&o.IsPaid==true)
                                .GroupBy(o1 => new { o1.OrderDate.Month,o1.OrderDate.Year})
                                .Select(o2 => new { Key = o2.Key, Total = o2.Sum(o => o.Total) });

            foreach (var ct in lsCTHD)
            {
                int month = ct.Key.Month;
                int year = ct.Key.Year;
                string dateTime = Convert.ToDateTime(month + "/" + year).ToString("M/yy");
                result[dateTime] = ct.Total;
            }

            for (DateTime date = date1; date <= date2; date = date.AddMonths(1))
            {
                string dateTime = date.ToString("M/yy");
                if (!result.ContainsKey(dateTime))
                {
                    result[dateTime] = 0;
                }
            }

            return result;
        }

        public SortedDictionary<int, float> TotalofYear(int year1,int year2)
        {
            DateTime date1 = new DateTime(year1, 1, 1);
            DateTime date2 = new DateTime(year2, 12, 31);

            SortedDictionary<int, float> result = new SortedDictionary<int, float>();

            var lsCTHD = dbContext.Orders
                                .Where(o => o.OrderDate >= date1 && o.OrderDate <= date2 && o.IsPaid == true)
                                .GroupBy(o1 => new { o1.OrderDate.Year })
                                .Select(o2 => new { Key = o2.Key, Total = o2.Sum(o => o.Total) });

            foreach (var ct in lsCTHD)
            {
                int year = ct.Key.Year;
                result[year] = ct.Total;
            }

            for (int year = year1; year <= year2; year++)
            {
                if (!result.ContainsKey(year))
                {
                    result[year] = 0;
                }
            }

            return result;
        }

        public SortedDictionary<int, float> TotalAll()
        {
            SortedDictionary<int, float> result = new SortedDictionary<int, float>();
            var lsCTHD = dbContext.OrderDetails.Include("Orders").Where(o => o.Order.IsPaid == true)
                                .GroupBy(o => new {o.FoodDrinkID})
                                .Select(o1 => new { Key = o1.Key, Total = o1.Sum(o => o.Quantity*o.Price) })
                                .OrderByDescending(o=> o.Total );
            // Order By : Tăng dần => Top least
            // Order by Descending: Giảm dần => Top most
            var totalall = dbContext.Orders.Where(o => o.IsPaid == true).Sum(o => o.Total);
            int count = 1;
            foreach (var ct in lsCTHD)
            {
                if (count > 5)
                    break;
                int id = ct.Key.FoodDrinkID;
                result[id] = (ct.Total / totalall) * 100;
                count++;
            }

            return result;
        }
        public SortedDictionary<int, float> TotalAllLeast ()
        {
            SortedDictionary<int, float> result = new SortedDictionary<int, float>();
            var lsCTHD = dbContext.OrderDetails.Include("Orders").Where(o => o.Order.IsPaid == true)
                                .GroupBy(o => new { o.FoodDrinkID })
                                .Select(o1 => new { Key = o1.Key, Total = o1.Sum(o => o.Quantity * o.Price) })
                                .OrderBy(o => o.Total);
            // Order By : Tăng dần => Top least
            // Order by Descending: Giảm dần => Top most
            var totalall = dbContext.Orders.Where(o => o.IsPaid == true).Sum(o => o.Total);
            int count = 1;
            foreach (var ct in lsCTHD)
            {
                if (count > 5)
                    break;
                int id = ct.Key.FoodDrinkID;
                result[id] = (ct.Total / totalall) * 100;
                count++;
            }
            return result;
        }
        public float GetTotalOrders()
        {
            return dbContext.Orders.Select(o => o.Total).Sum();
        }
    }
}
