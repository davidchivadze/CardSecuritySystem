namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeDeviceCardIDAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "DeviceCardID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "DeviceCardID");
        }
    }
}
