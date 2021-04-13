namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveEmployeePosition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeePositions", "IsActive", c => c.Boolean(nullable: false,defaultValue:true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeePositions", "IsActive");
        }
    }
}
