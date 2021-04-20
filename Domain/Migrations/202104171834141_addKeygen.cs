namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addKeygen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Keygens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        Company = c.String(),
                        KeyGen = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Keygens");
        }
    }
}
