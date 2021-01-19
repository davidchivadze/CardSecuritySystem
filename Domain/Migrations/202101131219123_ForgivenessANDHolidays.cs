namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForgivenessANDHolidays : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeHolidays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AllWritten = c.String(),
                        Left = c.String(),
                        Used = c.String(),
                        NumInYear = c.String(),
                        LeftInYear = c.String(),
                        DeactivateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Forgivenesses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ForgivenessTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ForgivenessTypes", t => t.ForgivenessTypeID, cascadeDelete: true)
                .Index(t => t.ForgivenessTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Forgivenesses", "ForgivenessTypeID", "dbo.ForgivenessTypes");
            DropForeignKey("dbo.EmployeeHolidays", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.Forgivenesses", new[] { "ForgivenessTypeID" });
            DropIndex("dbo.EmployeeHolidays", new[] { "EmployeeID" });
            DropTable("dbo.Forgivenesses");
            DropTable("dbo.EmployeeHolidays");
        }
    }
}
