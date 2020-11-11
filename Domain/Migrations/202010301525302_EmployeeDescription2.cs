namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeDescription2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Description_ka = c.String(),
                        Description_ru = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentDepartmentID = c.Int(nullable: false),
                        Description = c.String(maxLength: 250),
                        Description_ka = c.String(maxLength: 250),
                        Description_ru = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.ParentDepartmentID)
                .Index(t => t.ParentDepartmentID);
            
            CreateTable(
                "dbo.EmployeeDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        EmployeePositionID = c.Int(nullable: false),
                        SalaryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.EmployeePositions", t => t.EmployeePositionID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.EmployeePositionID);
            
            CreateTable(
                "dbo.EmployeePositions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartmentID = c.Int(nullable: false),
                        Description = c.String(maxLength: 250),
                        Description_ka = c.String(maxLength: 250),
                        Description_ru = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        IsHourly = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeDetails", "EmployeePositionID", "dbo.EmployeePositions");
            DropForeignKey("dbo.EmployeePositions", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.EmployeeDetails", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Departments", "ParentDepartmentID", "dbo.Departments");
            DropIndex("dbo.EmployeePositions", new[] { "DepartmentID" });
            DropIndex("dbo.EmployeeDetails", new[] { "EmployeePositionID" });
            DropIndex("dbo.EmployeeDetails", new[] { "EmployeeID" });
            DropIndex("dbo.Departments", new[] { "ParentDepartmentID" });
            DropTable("dbo.Salaries");
            DropTable("dbo.EmployeePositions");
            DropTable("dbo.EmployeeDetails");
            DropTable("dbo.Departments");
            DropTable("dbo.Currencies");
        }
    }
}
