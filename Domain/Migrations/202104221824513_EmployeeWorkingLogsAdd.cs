namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeWorkingLogsAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeWorkingLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        IndRegID = c.Int(nullable: false),
                        Minutes = c.Int(nullable: false),
                        EmployeeWorkingLogTimeTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeeWorkingLogTimeTypes", t => t.EmployeeWorkingLogTimeTypeID, cascadeDelete: true)
                .Index(t => t.EmployeeWorkingLogTimeTypeID);
            
            CreateTable(
                "dbo.EmployeeWorkingLogTimeTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeWorkingLogs", "EmployeeWorkingLogTimeTypeID", "dbo.EmployeeWorkingLogTimeTypes");
            DropIndex("dbo.EmployeeWorkingLogs", new[] { "EmployeeWorkingLogTimeTypeID" });
            DropTable("dbo.EmployeeWorkingLogTimeTypes");
            DropTable("dbo.EmployeeWorkingLogs");
        }
    }
}
