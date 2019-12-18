
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BLL
{
    public class StatictisBLL
    {
        StatisticDAL statisticDAL;
        public StatictisBLL()
        {
            statisticDAL = new StatisticDAL();
        }
        public SortedDictionary<string, float> TotalofDate(DateTime date1, DateTime date2)
        {
            return statisticDAL.TotalofDate(date1, date2);
        }

        public SortedDictionary<string, float> TotalofMonth(int month1, int year1, int month2, int year2)
        {
            return statisticDAL.TotalofMonth(month1, year1, month2, year2);
        }

        public SortedDictionary<int, float> TotalofYear(int year1, int year2)
        {
            return statisticDAL.TotalofYear(year1, year2);
        }
        public SortedDictionary<int, float> TotalAll(bool isTopMost)
        {
            if (isTopMost == true )
                return statisticDAL.TotalAll();
            return statisticDAL.TotalAllLeast();
        }
        public float GetTotal()
        {
            return statisticDAL.GetTotalOrders();
        }
    }
}
