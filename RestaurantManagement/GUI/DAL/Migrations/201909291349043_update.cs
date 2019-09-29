namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingTables",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        TableID = c.Int(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        ExpiredTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerID, t.TableID })
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Tables", t => t.TableID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.TableID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsFemale = c.Boolean(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        CMND = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        Total = c.Single(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        TableID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Tables", t => t.TableID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.TableID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        FoodDrinkID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Note = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.FoodDrinkID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.FoodDrinks", t => t.FoodDrinkID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.FoodDrinkID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsFemale = c.Boolean(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CMND = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.FoodDrinks",
                c => new
                    {
                        FoodDrinkID = c.Int(nullable: false, identity: true),
                        FoodDrinkName = c.String(nullable: false),
                        ImageURL = c.String(),
                        Description = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        IsFood = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FoodDrinkID);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        TableID = c.Int(nullable: false, identity: true),
                        TableName = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TableID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "TableID", "dbo.Tables");
            DropForeignKey("dbo.BookingTables", "TableID", "dbo.Tables");
            DropForeignKey("dbo.OrderDetails", "FoodDrinkID", "dbo.FoodDrinks");
            DropForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.BookingTables", "CustomerID", "dbo.Customers");
            DropIndex("dbo.OrderDetails", new[] { "FoodDrinkID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "EmployeeID" });
            DropIndex("dbo.Orders", new[] { "TableID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.BookingTables", new[] { "TableID" });
            DropIndex("dbo.BookingTables", new[] { "CustomerID" });
            DropTable("dbo.Tables");
            DropTable("dbo.FoodDrinks");
            DropTable("dbo.Employees");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.BookingTables");
        }
    }
}
