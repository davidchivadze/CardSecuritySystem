namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalaryType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalaryTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Salaries", "SalaryTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Salaries", "SalaryTypeID");
            AddForeignKey("dbo.Salaries", "SalaryTypeID", "dbo.SalaryTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "SalaryTypeID", "dbo.SalaryTypes");
            DropIndex("dbo.Salaries", new[] { "SalaryTypeID" });
            DropColumn("dbo.Salaries", "SalaryTypeID");
            DropTable("dbo.SalaryTypes");
        }
    }
}
