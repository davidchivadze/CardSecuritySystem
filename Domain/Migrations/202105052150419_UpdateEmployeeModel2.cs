namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
