namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGenders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.Employee", "Gender_ID", "dbo.Genders");
            DropIndex("dbo.Departments", new[] { "GenderID" });
            DropIndex("dbo.Employee", new[] { "Gender_ID" });
            RenameColumn(table: "dbo.Employee", name: "Gender_ID", newName: "GenderID");
            AlterColumn("dbo.Employee", "GenderID", c => c.Int(nullable: false));
            CreateIndex("dbo.Employee", "GenderID");
            AddForeignKey("dbo.Employee", "GenderID", "dbo.Genders", "ID", cascadeDelete: true);
            DropColumn("dbo.Departments", "GenderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "GenderID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employee", "GenderID", "dbo.Genders");
            DropIndex("dbo.Employee", new[] { "GenderID" });
            AlterColumn("dbo.Employee", "GenderID", c => c.Int());
            RenameColumn(table: "dbo.Employee", name: "GenderID", newName: "Gender_ID");
            CreateIndex("dbo.Employee", "Gender_ID");
            CreateIndex("dbo.Departments", "GenderID");
            AddForeignKey("dbo.Employee", "Gender_ID", "dbo.Genders", "ID");
            AddForeignKey("dbo.Departments", "GenderID", "dbo.Genders", "ID", cascadeDelete: true);
        }
    }
}
