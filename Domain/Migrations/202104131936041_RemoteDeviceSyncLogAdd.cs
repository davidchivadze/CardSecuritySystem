namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoteDeviceSyncLogAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RemoteDeviceSyncLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DeviceID = c.Int(nullable: false),
                        IsRuning = c.Boolean(nullable: false),
                        Error = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Devices", t => t.DeviceID, cascadeDelete: true)
                .Index(t => t.DeviceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RemoteDeviceSyncLogs", "DeviceID", "dbo.Devices");
            DropIndex("dbo.RemoteDeviceSyncLogs", new[] { "DeviceID" });
            DropTable("dbo.RemoteDeviceSyncLogs");
        }
    }
}
