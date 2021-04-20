namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDeviceRegistratedUsers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DeviceRegistratedUsers", "UserDeviceID", c => c.Int());
            AlterColumn("dbo.DeviceRegistratedUsers", "MachineNumber", c => c.Int());
            AlterColumn("dbo.DeviceRegistratedUsers", "FingerIndex", c => c.Int());
            AlterColumn("dbo.DeviceRegistratedUsers", "Privelage", c => c.Int());
            AlterColumn("dbo.DeviceRegistratedUsers", "Enabled", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DeviceRegistratedUsers", "Enabled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.DeviceRegistratedUsers", "Privelage", c => c.Int(nullable: false));
            AlterColumn("dbo.DeviceRegistratedUsers", "FingerIndex", c => c.Int(nullable: false));
            AlterColumn("dbo.DeviceRegistratedUsers", "MachineNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.DeviceRegistratedUsers", "UserDeviceID", c => c.Int(nullable: false));
        }
    }
}
