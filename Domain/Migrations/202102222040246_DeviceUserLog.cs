namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeviceUserLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceUserLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MachineNumber = c.Int(nullable: false),
                        IndRegID = c.Int(nullable: false),
                        dwVerifyMode = c.Int(nullable: false),
                        dwInOutMode = c.Int(nullable: false),
                        DateTimeRecord = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeviceUserLogs");
        }
    }
}
