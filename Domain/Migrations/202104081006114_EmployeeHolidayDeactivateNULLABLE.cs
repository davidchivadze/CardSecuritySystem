namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeHolidayDeactivateNULLABLE : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeHolidays", "DeactivateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeHolidays", "DeactivateDate", c => c.DateTime(nullable: false));
        }
    }
}
