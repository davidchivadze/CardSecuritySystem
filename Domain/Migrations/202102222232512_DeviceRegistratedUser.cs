namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeviceRegistratedUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceRegistratedUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserDeviceID = c.Int(nullable: false),
                        MachineNumber = c.Int(nullable: false),
                        Name = c.String(),
                        FingerIndex = c.Int(nullable: false),
                        TmpData = c.String(),
                        Privelage = c.Int(nullable: false),
                        Password = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        iFlag = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeviceRegistratedUsers");
        }
    }
}
