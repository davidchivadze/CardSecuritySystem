namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class branchesChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Branches", "Departments_ID", "dbo.Departments");
            DropIndex("dbo.Branches", new[] { "Departments_ID" });
            DropColumn("dbo.Branches", "Departments_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Branches", "Departments_ID", c => c.Int());
            CreateIndex("dbo.Branches", "Departments_ID");
            AddForeignKey("dbo.Branches", "Departments_ID", "dbo.Departments", "ID");
        }
    }
}
