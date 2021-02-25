namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HolidayTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HolidayTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.EmployeeHolidays", "HolidayTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeHolidays", "HolidayTypeID");
            AddForeignKey("dbo.EmployeeHolidays", "HolidayTypeID", "dbo.HolidayTypes", "ID", cascadeDelete: true);
            DropColumn("dbo.EmployeeHolidays", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeHolidays", "Name", c => c.String());
            DropForeignKey("dbo.EmployeeHolidays", "HolidayTypeID", "dbo.HolidayTypes");
            DropIndex("dbo.EmployeeHolidays", new[] { "HolidayTypeID" });
            DropColumn("dbo.EmployeeHolidays", "HolidayTypeID");
            DropTable("dbo.HolidayTypes");
        }
    }
}
