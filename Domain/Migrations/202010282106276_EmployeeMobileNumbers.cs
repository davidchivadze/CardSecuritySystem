namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeMobileNumbers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeMobileNumbers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        PhoneNumber = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirsName = c.String(nullable: false, maxLength: 250),
                        LastName = c.String(nullable: false, maxLength: 250),
                        DateOfBirth = c.String(nullable: false, maxLength: 250),
                        Address = c.String(maxLength: 250),
                        Email = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeMobileNumbers", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.EmployeeMobileNumbers", new[] { "EmployeeID" });
            DropTable("dbo.Employee");
            DropTable("dbo.EmployeeMobileNumbers");
        }
    }
}
