﻿namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleDeviceUserLogIsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.DeviceUserLogs", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeviceUserLogs", "IsActive");
            DropColumn("dbo.Schedules", "IsActive");
        }
    }
}
