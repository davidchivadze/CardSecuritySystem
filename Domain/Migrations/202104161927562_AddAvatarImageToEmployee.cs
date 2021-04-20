namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvatarImageToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Avatar", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Avatar");
        }
    }
}
