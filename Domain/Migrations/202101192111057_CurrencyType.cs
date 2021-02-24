namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrencyType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Currencies", "CurrencyTypeId", "dbo.CurrencyTypes");
            DropIndex("dbo.Currencies", new[] { "CurrencyTypeId" });
            RenameColumn(table: "dbo.Currencies", name: "CurrencyTypeId", newName: "CurrencyType_ID");
            AlterColumn("dbo.Currencies", "CurrencyType_ID", c => c.Int());
            CreateIndex("dbo.Currencies", "CurrencyType_ID");
            AddForeignKey("dbo.Currencies", "CurrencyType_ID", "dbo.CurrencyTypes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Currencies", "CurrencyType_ID", "dbo.CurrencyTypes");
            DropIndex("dbo.Currencies", new[] { "CurrencyType_ID" });
            AlterColumn("dbo.Currencies", "CurrencyType_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Currencies", name: "CurrencyType_ID", newName: "CurrencyTypeId");
            CreateIndex("dbo.Currencies", "CurrencyTypeId");
            AddForeignKey("dbo.Currencies", "CurrencyTypeId", "dbo.CurrencyTypes", "ID", cascadeDelete: true);
        }
    }
}
