namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeDescriptionAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeMobileNumbers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employee", "FirsName_ka", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Employee", "FirsName_ru", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Employee", "LastName_ka", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Employee", "LastName_ru", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Employee", "Address_ka", c => c.String(maxLength: 250));
            AddColumn("dbo.Employee", "Address_ru", c => c.String(maxLength: 250));
            AlterColumn("dbo.Employee", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "DateOfBirth", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.Employee", "Address_ru");
            DropColumn("dbo.Employee", "Address_ka");
            DropColumn("dbo.Employee", "LastName_ru");
            DropColumn("dbo.Employee", "LastName_ka");
            DropColumn("dbo.Employee", "FirsName_ru");
            DropColumn("dbo.Employee", "FirsName_ka");
            DropColumn("dbo.EmployeeMobileNumbers", "IsActive");
        }
    }
}
