namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeAddDeviceUserID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "UserIDInDevice", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "UserIDInDevice");
        }
    }
}
