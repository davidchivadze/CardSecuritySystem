namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeePersonalNumberAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "PersonalNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "PersonalNumber");
        }
    }
}
