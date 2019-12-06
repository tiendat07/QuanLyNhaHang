using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class TableDAL
    {
        RestaurantContextEntities dbContext;
        public TableDAL()
        {
            dbContext = new RestaurantContextEntities();
        }
        public List<Table> GetListTable()
        {
            return dbContext.Tables.ToList();
        }
        public bool ChangeTableStatus(int TableID, bool isOrdered, bool isPaid, bool isBooked)
        {
            if (TableID > 0)
            {
                var x = dbContext.Tables.Where(t => t.TableID == TableID).FirstOrDefault();
                if (x != null)
                {
                    if (isOrdered == true)
                    {
                        x.Status = 2;
                    }
                    else if (isPaid == true)
                    {
                        x.Status = 0;
                    }
                    else if (isBooked == true)
                    {
                        x.Status = 1;
                    }
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }
        public bool EditTable(Table table)
        {
            try
            {
                if (table != null)
                {
                    Table table_temp = dbContext.Tables.Where(d => d.TableID == table.TableID).FirstOrDefault();
                    if (table_temp == null)
                        return false;
                    table_temp.TableID = table.TableID;
                    table_temp.TableName = table.TableName;
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
