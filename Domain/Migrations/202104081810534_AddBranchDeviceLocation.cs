namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBranchDeviceLocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceLocationInBranchBranches",
                c => new
                    {
                        DeviceLocationInBranch_ID = c.Int(nullable: false),
                        Branch_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeviceLocationInBranch_ID, t.Branch_ID })
                .ForeignKey("dbo.DeviceLocationInBranches", t => t.DeviceLocationInBranch_ID, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.Branch_ID, cascadeDelete: true)
                .Index(t => t.DeviceLocationInBranch_ID)
                .Index(t => t.Branch_ID);
            
            AddColumn("dbo.DeviceLocationInBranches", "BranchID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceLocationInBranchBranches", "Branch_ID", "dbo.Branches");
            DropForeignKey("dbo.DeviceLocationInBranchBranches", "DeviceLocationInBranch_ID", "dbo.DeviceLocationInBranches");
            DropIndex("dbo.DeviceLocationInBranchBranches", new[] { "Branch_ID" });
            DropIndex("dbo.DeviceLocationInBranchBranches", new[] { "DeviceLocationInBranch_ID" });
            DropColumn("dbo.DeviceLocationInBranches", "BranchID");
            DropTable("dbo.DeviceLocationInBranchBranches");
        }
    }
}
