namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationChange1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RemoteDeviceSyncLogs", "DeviceID", "dbo.Devices");
            DropIndex("dbo.RemoteDeviceSyncLogs", new[] { "DeviceID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.RemoteDeviceSyncLogs", "DeviceID");
            AddForeignKey("dbo.RemoteDeviceSyncLogs", "DeviceID", "dbo.Devices", "ID");
        }
    }
}
