namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddScheduleGenerator : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduleGenerators",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ScheduleTypeID = c.Int(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        MinCheckInTime = c.Time(nullable: false, precision: 7),
                        MaxCheckOutTime = c.Time(nullable: false, precision: 7),
                        BreakAmount = c.Double(nullable: false),
                        WeekHouresAmount = c.Int(nullable: false),
                        DaylyHouresAmount = c.Int(nullable: false),
                        OnWorkingDaysOnly = c.Boolean(nullable: false),
                        OnWorkingHouresOnly = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ScheduleTypes", t => t.ScheduleTypeID, cascadeDelete: true)
                .Index(t => t.ScheduleTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleGenerators", "ScheduleTypeID", "dbo.ScheduleTypes");
            DropIndex("dbo.ScheduleGenerators", new[] { "ScheduleTypeID" });
            DropTable("dbo.ScheduleGenerators");
        }
    }
}
