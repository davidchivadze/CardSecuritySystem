namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationEmployeeFINEforgiveness : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeDetails", "FineID", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeDetails", "ForgivenessID", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeDetails", "FineID");
            CreateIndex("dbo.EmployeeDetails", "ForgivenessID");
            AddForeignKey("dbo.EmployeeDetails", "FineID", "dbo.Fines", "ID", cascadeDelete: false);
            AddForeignKey("dbo.EmployeeDetails", "ForgivenessID", "dbo.Forgivenesses", "ID", cascadeDelete: false); ;
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeDetails", "ForgivenessID", "dbo.Forgivenesses");
            DropForeignKey("dbo.EmployeeDetails", "FineID", "dbo.Fines");
            DropIndex("dbo.EmployeeDetails", new[] { "ForgivenessID" });
            DropIndex("dbo.EmployeeDetails", new[] { "FineID" });
            DropColumn("dbo.EmployeeDetails", "ForgivenessID");
            DropColumn("dbo.EmployeeDetails", "FineID");
        }
    }
}
