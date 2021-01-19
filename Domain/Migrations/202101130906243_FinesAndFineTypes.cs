namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinesAndFineTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        FineTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Currencies", t => t.CurrencyID, cascadeDelete: true)
                .ForeignKey("dbo.FineTypes", t => t.FineTypeID, cascadeDelete: true)
                .Index(t => t.CurrencyID)
                .Index(t => t.FineTypeID);
            
            CreateTable(
                "dbo.FineTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fines", "FineTypeID", "dbo.FineTypes");
            DropForeignKey("dbo.Fines", "CurrencyID", "dbo.Currencies");
            DropIndex("dbo.Fines", new[] { "FineTypeID" });
            DropIndex("dbo.Fines", new[] { "CurrencyID" });
            DropTable("dbo.FineTypes");
            DropTable("dbo.Fines");
        }
    }
}
