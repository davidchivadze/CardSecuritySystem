namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmployeeHolidayVarTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeHolidays", "AllWritten", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeHolidays", "Left", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeHolidays", "Used", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeHolidays", "NumInYear", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeHolidays", "LeftInYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeHolidays", "LeftInYear", c => c.String());
            AlterColumn("dbo.EmployeeHolidays", "NumInYear", c => c.String());
            AlterColumn("dbo.EmployeeHolidays", "Used", c => c.String());
            AlterColumn("dbo.EmployeeHolidays", "Left", c => c.String());
            AlterColumn("dbo.EmployeeHolidays", "AllWritten", c => c.String());
        }
    }
}
