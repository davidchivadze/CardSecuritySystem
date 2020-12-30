namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDepartments : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Departments", "ParentDepartmentID");
            RenameColumn(table: "dbo.Departments", name: "Departments_ID", newName: "ParentDepartmentID");
            RenameIndex(table: "dbo.Departments", name: "IX_Departments_ID", newName: "IX_ParentDepartmentID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Departments", name: "IX_ParentDepartmentID", newName: "IX_Departments_ID");
            RenameColumn(table: "dbo.Departments", name: "ParentDepartmentID", newName: "Departments_ID");
            AddColumn("dbo.Departments", "ParentDepartmentID", c => c.Int());
        }
    }
}
