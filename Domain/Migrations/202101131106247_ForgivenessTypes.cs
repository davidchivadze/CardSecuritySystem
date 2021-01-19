namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForgivenessTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ForgivenessTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ForgivenessTypes");
        }
    }
}
