namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentBranchIsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branches", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Departments", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "IsActive");
            DropColumn("dbo.Branches", "IsActive");
        }
    }
}
