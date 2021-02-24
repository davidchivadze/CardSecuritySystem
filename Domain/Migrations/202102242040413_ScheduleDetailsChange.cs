namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleDetailsChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "ScheduleDetailID", "dbo.ScheduleDetails");
            DropIndex("dbo.Schedules", new[] { "ScheduleDetailID" });
            CreateTable(
                "dbo.ScheduleDetailsSchedules",
                c => new
                    {
                        ScheduleDetails_ID = c.Int(nullable: false),
                        Schedule_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ScheduleDetails_ID, t.Schedule_ID })
                .ForeignKey("dbo.ScheduleDetails", t => t.ScheduleDetails_ID, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ID, cascadeDelete: true)
                .Index(t => t.ScheduleDetails_ID)
                .Index(t => t.Schedule_ID);
            
            AddColumn("dbo.ScheduleDetails", "ScheduleID", c => c.Int(nullable: false));
            DropColumn("dbo.Schedules", "ScheduleDetailID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "ScheduleDetailID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ScheduleDetailsSchedules", "Schedule_ID", "dbo.Schedules");
            DropForeignKey("dbo.ScheduleDetailsSchedules", "ScheduleDetails_ID", "dbo.ScheduleDetails");
            DropIndex("dbo.ScheduleDetailsSchedules", new[] { "Schedule_ID" });
            DropIndex("dbo.ScheduleDetailsSchedules", new[] { "ScheduleDetails_ID" });
            DropColumn("dbo.ScheduleDetails", "ScheduleID");
            DropTable("dbo.ScheduleDetailsSchedules");
            CreateIndex("dbo.Schedules", "ScheduleDetailID");
            AddForeignKey("dbo.Schedules", "ScheduleDetailID", "dbo.ScheduleDetails", "ID", cascadeDelete: true);
        }
    }
}
