namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATECityRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "CountryID", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "CountryID" });
            AlterColumn("dbo.Cities", "CountryID", c => c.Int(nullable: false,defaultValue:1));
            CreateIndex("dbo.Cities", "CountryID");
            AddForeignKey("dbo.Cities", "CountryID", "dbo.Countries", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "CountryID", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "CountryID" });
            AlterColumn("dbo.Cities", "CountryID", c => c.Int());
            CreateIndex("dbo.Cities", "CountryID");
            AddForeignKey("dbo.Cities", "CountryID", "dbo.Countries", "ID");
        }
    }
}
