namespace DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Model;
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.RestaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.RestaurantContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Customers.AddOrUpdate(p => p.CustomerID, 
                new Customer { Name = "Nguyen Thi Phuong Lan", IsFemale = true, PhoneNumber = "0921009221", CMND = "012345678910" },
                new Customer { Name = "Nguyen Nam", IsFemale = false, PhoneNumber = "0921009220", CMND = "112345678910" },
                new Customer { Name = "Nguyen Van Nhan", IsFemale = false, PhoneNumber = "0921009222", CMND = "212345678910" },
                new Customer { Name = "Dương Bảo San", IsFemale = true, PhoneNumber = "0921309222", CMND = "312345678910" },
                new Customer { Name = "Trần Thị Quỳnh Như", IsFemale = true, PhoneNumber = "0921309232", CMND = "312345678911" },
                new Customer { Name = "Trần Dương Vân Anh", IsFemale = true, PhoneNumber = "0921309235", CMND = "312345678912" },
                new Customer { Name = "Trần Dương Hà Lan", IsFemale = true, PhoneNumber = "0921309238", CMND = "312345678012" },
                new Customer { Name = "Hà Gia Bảo", IsFemale = false, PhoneNumber = "0121309238", CMND = "013345678012" },
                new Customer { Name = "Dương Cường", IsFemale = false, PhoneNumber = "0126309238", CMND = "013342678012" });

            context.Employees.AddOrUpdate(e => e.EmployeeID,
                new Employee { Name = "Pham Ngoc Thinh", IsFemale = false, DateOfBirth = new DateTime(2000, 12, 23), PhoneNumber = "0126777777", Address = "222 Nguyen Cong Tru, Thu Duc", CMND = "123453181123", Email = "thinhthinh@gmail.com", Username = "thinhthinh", Password = BCrypt.Net.BCrypt.HashPassword("ABCDE21"), IsAdmin = false },
                new Employee { Name = "Tran Van Bao", IsFemale = false, DateOfBirth = new DateTime(2000, 6, 22), PhoneNumber = "0126888888", Address = "222 Lam Truong, Thu Duc", CMND = "123454181123", Email = "tranvanbao@gmail.com", Username = "baobao", Password = BCrypt.Net.BCrypt.HashPassword("BAO1235"), IsAdmin = false },
                new Employee { Name = "Nguyễn Đắc Thiên Ngân", IsFemale = true, DateOfBirth = new DateTime(2000, 5, 15), PhoneNumber = "0126999999", Address = "239 Nguyễn Kiệm, Gò Vấp", CMND = "123454181123", Email = "nguyendacthienngan@gmail.com", Username = "thienngan1505", Password = BCrypt.Net.BCrypt.HashPassword("NGAN2000"), IsAdmin = true },
                new Employee { Name = "Ung Bảo Tiên", IsFemale = true, DateOfBirth = new DateTime(2000, 12, 5), PhoneNumber = "0126000000", Address = "200 Quang Trung, Gò Vấp", CMND = "123454181133", Email = "ungbaotien@gmail.com", Username = "tientien", Password = BCrypt.Net.BCrypt.HashPassword("TIENTIEN"), IsAdmin = false });

            context.Tables.AddOrUpdate(t => t.TableID,
                new Table { TableName = "Bàn 1", Status = 0 },
                new Table { TableName = "Bàn 2", Status = 1 },
                new Table { TableName = "Bàn 3", Status = 2 },
                new Table { TableName = "Bàn 4", Status = 0 },
                new Table { TableName = "Bàn 5", Status = 1 },
                new Table { TableName = "Bàn 6", Status = 0 },
                new Table { TableName = "Bàn 7", Status = 2 },
                new Table { TableName = "Bàn 8", Status = 1 },
                new Table { TableName = "Bàn 9", Status = 0 });

            string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName);
            context.FoodDrinks.AddOrUpdate(f => f.FoodDrinkID,
                new FoodDrink
                {
                    FoodDrinkName = "Gà sốt mật ong",
                    ImageURL = string.Format(@"{0}\GUI\GUI\Resources\canhgasotmatong.jpg", startupPath),

            Description = "Món ăn thơm ngon",
                    IsAvailable = true,
                    IsFood = true
                },
                new FoodDrink
                {
                    FoodDrinkName = "Soda chanh đường",
                    ImageURL = string.Format(@"{0}\GUI\GUI\Resources\chanh-pha-soda.jpg", startupPath),
                    Description = "Giải khát cho những ngày nóng bức",
                    IsAvailable = true,
                    IsFood = false
                },
                new FoodDrink
                {
                    FoodDrinkName = "Cafe đá",
                    ImageURL = string.Format(@"{0}\GUI\GUI\Resources\cafe-den.jpg", startupPath),
                    Description = "Giải khát cho những ngày nóng bức",
                    IsAvailable = false,
                    IsFood = false
                },
                new FoodDrink
                {
                    FoodDrinkName = "Cơm chiên hải sản",
                    ImageURL = string.Format(@"{0}\GUI\GUI\Resources\com-chien-hai-san-nha-hang.jpg", startupPath),
                    Description = "Món ăn thơm ngon",
                    IsAvailable = true,
                    IsFood = true
                });
            context.SaveChanges();
            List<Customer> customers = context.Customers.ToList();
            List<Employee> employees = context.Employees.ToList();
            List<Table> tables = context.Tables.ToList();
            List<FoodDrink> foodDrinks = context.FoodDrinks.ToList();
            context.Orders.AddOrUpdate(o => o.OrderID, 
                new Order
                {
                    CustomerID = customers[0].CustomerID,
                    EmployeeID = employees[0].EmployeeID,
                    TableID = tables[0].TableID,
                    OrderDate = new DateTime(2019, 8, 29),
                    IsPaid = false,
                    Total = 130000
                },
                new Order
                {
                    CustomerID = customers[1].CustomerID,
                    EmployeeID = employees[1].EmployeeID,
                    TableID = tables[1].TableID,
                    OrderDate = new DateTime(2019, 8, 29),
                    IsPaid = true,
                    Total = 150000
                }
                );
            context.SaveChanges();
            List<Order> orders = context.Orders.ToList();
            context.OrderDetails.AddOrUpdate(o => o.OrderID,
                new OrderDetail
                {
                    OrderID = orders[0].OrderID,
                    FoodDrinkID = foodDrinks[0].FoodDrinkID,
                    Quantity = 3,
                    Note = "Không cay",
                    Price = 300000

                },
                new OrderDetail
                {
                    OrderID = orders[1].OrderID,
                    FoodDrinkID = foodDrinks[1].FoodDrinkID,
                    Quantity = 1,
                    Note = "Không hành",
                    Price = 450000
                });
            context.SaveChanges();
            List<OrderDetail> orderDetails = context.OrderDetails.ToList();
            context.BookingTables.AddOrUpdate(b => b.CustomerID,
                new BookingTable
                {
                    CustomerID = customers[0].CustomerID,
                    TableID = tables[0].TableID,
                    BookingDate = new DateTime(2019,8,9,9,20,0),
                    ExpiredTime = new DateTime (2019,8,9,10,20,0)
                },
                new BookingTable
                {
                    CustomerID = customers[1].CustomerID,
                    TableID = tables[3].TableID,
                    BookingDate = new DateTime(2019, 9, 29, 15, 20, 0),
                    ExpiredTime = new DateTime(2019, 9, 29, 16, 20, 0)
                }
            );
            
            base.Seed(context);
        }
    }
}
