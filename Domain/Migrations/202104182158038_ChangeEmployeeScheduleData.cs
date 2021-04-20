namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmployeeScheduleData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "MinCheckInTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Schedules", "MaxCheckOutTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Schedules", "BreakAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "BreakAmount");
            DropColumn("dbo.Schedules", "MaxCheckOutTime");
            DropColumn("dbo.Schedules", "MinCheckInTime");
        }
    }
}
