namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                        Address = c.String(),
                        BranchName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CityID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Description_ka = c.String(),
                        Description_ru = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Description_ka = c.String(),
                        Description_ru = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.EmployeeDetails", "BranchID", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeDetails", "SalaryID");
            CreateIndex("dbo.EmployeeDetails", "BranchID");
            CreateIndex("dbo.Salaries", "CurrencyID");
            AddForeignKey("dbo.EmployeeDetails", "BranchID", "dbo.Branches", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Salaries", "CurrencyID", "dbo.Currencies", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeDetails", "SalaryID", "dbo.Salaries", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeDetails", "SalaryID", "dbo.Salaries");
            DropForeignKey("dbo.Salaries", "CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.EmployeeDetails", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.Branches", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Branches", "CityID", "dbo.Cities");
            DropIndex("dbo.Salaries", new[] { "CurrencyID" });
            DropIndex("dbo.Branches", new[] { "CountryID" });
            DropIndex("dbo.Branches", new[] { "CityID" });
            DropIndex("dbo.EmployeeDetails", new[] { "BranchID" });
            DropIndex("dbo.EmployeeDetails", new[] { "SalaryID" });
            DropColumn("dbo.EmployeeDetails", "BranchID");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Branches");
        }
    }
}
