namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEmployeeDetailsID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeDetails", "EmployeeID", "dbo.Employee");
            DropPrimaryKey("dbo.EmployeeDetails");
            AddPrimaryKey("dbo.EmployeeDetails", "EmployeeID");
            AddForeignKey("dbo.EmployeeDetails", "EmployeeID", "dbo.Employee", "ID");
            DropColumn("dbo.EmployeeDetails", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeDetails", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.EmployeeDetails", "EmployeeID", "dbo.Employee");
            DropPrimaryKey("dbo.EmployeeDetails");
            AddPrimaryKey("dbo.EmployeeDetails", "ID");
            AddForeignKey("dbo.EmployeeDetails", "EmployeeID", "dbo.Employee", "ID", cascadeDelete: true);
        }
    }
}
