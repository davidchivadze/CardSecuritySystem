namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHolidayeReuest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeHolidayRequests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegistartionDate = c.DateTime(nullable: false),
                        HolidayTypeID = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        AmountWorkDays = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.HolidayTypes", t => t.HolidayTypeID, cascadeDelete: true)
                .Index(t => t.HolidayTypeID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.GovernmentHolidays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HolidayDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
           
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeHolidayRequests", "HolidayTypeID", "dbo.HolidayTypes");
            DropForeignKey("dbo.EmployeeHolidayRequests", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.EmployeeHolidayRequests", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeHolidayRequests", new[] { "HolidayTypeID" });
            DropTable("dbo.GovernmentHolidays");
            DropTable("dbo.EmployeeHolidayRequests");
        }
    }
}
