namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingTables",
                c => new
                    {
                        BookingTableID = c.String(nullable: false, maxLength: 128),
                        BookingDate = c.DateTime(nullable: false),
                        ExpiredTime = c.DateTime(nullable: false),
                        Customer_ID = c.String(maxLength: 128),
                        Table_TableID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookingTableID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .ForeignKey("dbo.Tables", t => t.Table_TableID)
                .Index(t => t.Customer_ID)
                .Index(t => t.Table_TableID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Gender = c.Boolean(nullable: false),
                        PhoneNumber = c.String(),
                        CMND = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Gender = c.Boolean(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        CMND = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FoodDrinks",
                c => new
                    {
                        FoodDrinkID = c.String(nullable: false, maxLength: 128),
                        FoodDrinkName = c.String(),
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
                        TableID = c.String(nullable: false, maxLength: 128),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TableID);
            
            AddColumn("dbo.OrderDetails", "x", c => c.String());
            AddColumn("dbo.OrderDetails", "FoodDrink_FoodDrinkID", c => c.String(maxLength: 128));
            AddColumn("dbo.Orders", "Customer_ID", c => c.String(maxLength: 128));
            AddColumn("dbo.Orders", "Employee_ID", c => c.String(maxLength: 128));
            AddColumn("dbo.Orders", "Table_TableID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "Customer_ID");
            CreateIndex("dbo.Orders", "Employee_ID");
            CreateIndex("dbo.Orders", "Table_TableID");
            CreateIndex("dbo.OrderDetails", "FoodDrink_FoodDrinkID");
            AddForeignKey("dbo.Orders", "Customer_ID", "dbo.Customers", "ID");
            AddForeignKey("dbo.Orders", "Employee_ID", "dbo.Employees", "ID");
            AddForeignKey("dbo.OrderDetails", "FoodDrink_FoodDrinkID", "dbo.FoodDrinks", "FoodDrinkID");
            AddForeignKey("dbo.Orders", "Table_TableID", "dbo.Tables", "TableID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Table_TableID", "dbo.Tables");
            DropForeignKey("dbo.BookingTables", "Table_TableID", "dbo.Tables");
            DropForeignKey("dbo.OrderDetails", "FoodDrink_FoodDrinkID", "dbo.FoodDrinks");
            DropForeignKey("dbo.Orders", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.Orders", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.BookingTables", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.OrderDetails", new[] { "FoodDrink_FoodDrinkID" });
            DropIndex("dbo.Orders", new[] { "Table_TableID" });
            DropIndex("dbo.Orders", new[] { "Employee_ID" });
            DropIndex("dbo.Orders", new[] { "Customer_ID" });
            DropIndex("dbo.BookingTables", new[] { "Table_TableID" });
            DropIndex("dbo.BookingTables", new[] { "Customer_ID" });
            DropColumn("dbo.Orders", "Table_TableID");
            DropColumn("dbo.Orders", "Employee_ID");
            DropColumn("dbo.Orders", "Customer_ID");
            DropColumn("dbo.OrderDetails", "FoodDrink_FoodDrinkID");
            DropColumn("dbo.OrderDetails", "x");
            DropTable("dbo.Tables");
            DropTable("dbo.FoodDrinks");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.BookingTables");
        }
    }
}
