namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBranchDeviceLocationRealtionChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeviceLocationInBranchBranches", "DeviceLocationInBranch_ID", "dbo.DeviceLocationInBranches");
            DropForeignKey("dbo.DeviceLocationInBranchBranches", "Branch_ID", "dbo.Branches");
            DropIndex("dbo.DeviceLocationInBranchBranches", new[] { "DeviceLocationInBranch_ID" });
            DropIndex("dbo.DeviceLocationInBranchBranches", new[] { "Branch_ID" });
            CreateIndex("dbo.DeviceLocationInBranches", "BranchID");
            AddForeignKey("dbo.DeviceLocationInBranches", "BranchID", "dbo.Branches", "ID", cascadeDelete: true);
            DropTable("dbo.DeviceLocationInBranchBranches");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DeviceLocationInBranchBranches",
                c => new
                    {
                        DeviceLocationInBranch_ID = c.Int(nullable: false),
                        Branch_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeviceLocationInBranch_ID, t.Branch_ID });
            
            DropForeignKey("dbo.DeviceLocationInBranches", "BranchID", "dbo.Branches");
            DropIndex("dbo.DeviceLocationInBranches", new[] { "BranchID" });
            CreateIndex("dbo.DeviceLocationInBranchBranches", "Branch_ID");
            CreateIndex("dbo.DeviceLocationInBranchBranches", "DeviceLocationInBranch_ID");
            AddForeignKey("dbo.DeviceLocationInBranchBranches", "Branch_ID", "dbo.Branches", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DeviceLocationInBranchBranches", "DeviceLocationInBranch_ID", "dbo.DeviceLocationInBranches", "ID", cascadeDelete: true);
        }
    }
}
