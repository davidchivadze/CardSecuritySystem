namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDCountryCityRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "CountryID", c => c.Int());
            CreateIndex("dbo.Cities", "CountryID");
            AddForeignKey("dbo.Cities", "CountryID", "dbo.Countries", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "CountryID", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "CountryID" });
            DropColumn("dbo.Cities", "CountryID");
        }
    }
}
