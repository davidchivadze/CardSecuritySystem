namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RemoteDeviceSyncLogs", "DeviceID", "dbo.Devices");
            DropIndex("dbo.RemoteDeviceSyncLogs", new[] { "DeviceID" });
            AlterColumn("dbo.RemoteDeviceSyncLogs", "DeviceID", c => c.Int());
            CreateIndex("dbo.RemoteDeviceSyncLogs", "DeviceID");
            AddForeignKey("dbo.RemoteDeviceSyncLogs", "DeviceID", "dbo.Devices", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RemoteDeviceSyncLogs", "DeviceID", "dbo.Devices");
            DropIndex("dbo.RemoteDeviceSyncLogs", new[] { "DeviceID" });
            AlterColumn("dbo.RemoteDeviceSyncLogs", "DeviceID", c => c.Int(nullable: false));
            CreateIndex("dbo.RemoteDeviceSyncLogs", "DeviceID");
            AddForeignKey("dbo.RemoteDeviceSyncLogs", "DeviceID", "dbo.Devices", "ID", cascadeDelete: true);
        }
    }
}
