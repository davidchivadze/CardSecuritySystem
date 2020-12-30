namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Departments", "GenderID", c => c.Int(nullable: false));
            AddColumn("dbo.Employee", "Gender_ID", c => c.Int());
            CreateIndex("dbo.Departments", "GenderID");
            CreateIndex("dbo.Employee", "Gender_ID");
            AddForeignKey("dbo.Employee", "Gender_ID", "dbo.Genders", "ID");
            AddForeignKey("dbo.Departments", "GenderID", "dbo.Genders", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.Employee", "Gender_ID", "dbo.Genders");
            DropIndex("dbo.Employee", new[] { "Gender_ID" });
            DropIndex("dbo.Departments", new[] { "GenderID" });
            DropColumn("dbo.Employee", "Gender_ID");
            DropColumn("dbo.Departments", "GenderID");
            DropTable("dbo.Genders");
        }
    }
}
