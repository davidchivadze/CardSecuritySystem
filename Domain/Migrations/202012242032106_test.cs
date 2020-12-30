namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                        Address = c.String(),
                        BranchName = c.String(),
                        Departments_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Departments_ID)
                .Index(t => t.CityID)
                .Index(t => t.CountryID)
                .Index(t => t.Departments_ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Description_ka = c.String(),
                        Description_ru = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Description_ka = c.String(),
                        Description_ru = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Description_ka = c.String(),
                        Description_ru = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentDepartmentID = c.Int(),
                        Description = c.String(maxLength: 250),
                        Description_ka = c.String(maxLength: 250),
                        Description_ru = c.String(maxLength: 250),
                        Departments_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.Departments_ID)
                .Index(t => t.Departments_ID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirsName = c.String(nullable: false, maxLength: 250),
                        FirsName_ka = c.String(nullable: false, maxLength: 250),
                        FirsName_ru = c.String(nullable: false, maxLength: 250),
                        LastName = c.String(nullable: false, maxLength: 250),
                        LastName_ka = c.String(nullable: false, maxLength: 250),
                        LastName_ru = c.String(nullable: false, maxLength: 250),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 250),
                        Address_ka = c.String(maxLength: 250),
                        Address_ru = c.String(maxLength: 250),
                        Email = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                        EmployeeDetails_ID = c.Int(),
                        Departments_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeeDetails", t => t.EmployeeDetails_ID)
                .ForeignKey("dbo.Schedules", t => t.ScheduleID, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Departments_ID)
                .Index(t => t.ScheduleID)
                .Index(t => t.EmployeeDetails_ID)
                .Index(t => t.Departments_ID);
            
            CreateTable(
                "dbo.EmployeeDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        EmployeePositionID = c.Int(nullable: false),
                        SalaryID = c.Int(nullable: false),
                        BranchID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Branches", t => t.BranchID, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.EmployeePositions", t => t.EmployeePositionID, cascadeDelete: true)
                .ForeignKey("dbo.Salaries", t => t.SalaryID, cascadeDelete: true)
                .Index(t => t.EmployeePositionID)
                .Index(t => t.SalaryID)
                .Index(t => t.BranchID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.EmployeePositions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 250),
                        Description_ka = c.String(maxLength: 250),
                        Description_ru = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        IsHourly = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Currencies", t => t.CurrencyID, cascadeDelete: true)
                .Index(t => t.CurrencyID);
            
            CreateTable(
                "dbo.EmployeeMobileNumbers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        PhoneNumber = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ScheduleTypeID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        WeekHouresAmount = c.Int(nullable: false),
                        DaylyHouresAmount = c.Int(nullable: false),
                        OnWorkingDaysOnly = c.Boolean(nullable: false),
                        OnWorkingHouresOnly = c.Boolean(nullable: false),
                        NotStandartSchedule = c.Boolean(nullable: false),
                        ScheduleDetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ScheduleDetails", t => t.ScheduleDetailID, cascadeDelete: true)
                .ForeignKey("dbo.ScheduleTypes", t => t.ScheduleTypeID, cascadeDelete: true)
                .Index(t => t.ScheduleTypeID)
                .Index(t => t.ScheduleDetailID);
            
            CreateTable(
                "dbo.ScheduleDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        HasPassed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ScheduleTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DeviceLocationInBranches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberDevices = c.Int(nullable: false),
                        IPAddress = c.String(),
                        LastSyncDate = c.DateTime(nullable: false),
                        DeviceTypeID = c.Int(nullable: false),
                        BranchID = c.Int(nullable: false),
                        DeviceLocationInBranchID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Port = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Branches", t => t.BranchID, cascadeDelete: true)
                .ForeignKey("dbo.DeviceLocationInBranches", t => t.DeviceLocationInBranchID, cascadeDelete: true)
                .ForeignKey("dbo.DeviceTypes", t => t.DeviceTypeID, cascadeDelete: true)
                .Index(t => t.DeviceTypeID)
                .Index(t => t.BranchID)
                .Index(t => t.DeviceLocationInBranchID);
            
            CreateTable(
                "dbo.DeviceTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "DeviceTypeID", "dbo.DeviceTypes");
            DropForeignKey("dbo.Devices", "DeviceLocationInBranchID", "dbo.DeviceLocationInBranches");
            DropForeignKey("dbo.Devices", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.Departments", "Departments_ID", "dbo.Departments");
            DropForeignKey("dbo.Employee", "Departments_ID", "dbo.Departments");
            DropForeignKey("dbo.Employee", "ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "ScheduleTypeID", "dbo.ScheduleTypes");
            DropForeignKey("dbo.Schedules", "ScheduleDetailID", "dbo.ScheduleDetails");
            DropForeignKey("dbo.EmployeeMobileNumbers", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.EmployeeDetails", "SalaryID", "dbo.Salaries");
            DropForeignKey("dbo.Salaries", "CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.EmployeeDetails", "EmployeePositionID", "dbo.EmployeePositions");
            DropForeignKey("dbo.Employee", "EmployeeDetails_ID", "dbo.EmployeeDetails");
            DropForeignKey("dbo.EmployeeDetails", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.EmployeeDetails", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.Branches", "Departments_ID", "dbo.Departments");
            DropForeignKey("dbo.Branches", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Branches", "CityID", "dbo.Cities");
            DropIndex("dbo.Devices", new[] { "DeviceLocationInBranchID" });
            DropIndex("dbo.Devices", new[] { "BranchID" });
            DropIndex("dbo.Devices", new[] { "DeviceTypeID" });
            DropIndex("dbo.Schedules", new[] { "ScheduleDetailID" });
            DropIndex("dbo.Schedules", new[] { "ScheduleTypeID" });
            DropIndex("dbo.EmployeeMobileNumbers", new[] { "EmployeeID" });
            DropIndex("dbo.Salaries", new[] { "CurrencyID" });
            DropIndex("dbo.EmployeeDetails", new[] { "DepartmentID" });
            DropIndex("dbo.EmployeeDetails", new[] { "BranchID" });
            DropIndex("dbo.EmployeeDetails", new[] { "SalaryID" });
            DropIndex("dbo.EmployeeDetails", new[] { "EmployeePositionID" });
            DropIndex("dbo.Employee", new[] { "Departments_ID" });
            DropIndex("dbo.Employee", new[] { "EmployeeDetails_ID" });
            DropIndex("dbo.Employee", new[] { "ScheduleID" });
            DropIndex("dbo.Departments", new[] { "Departments_ID" });
            DropIndex("dbo.Branches", new[] { "Departments_ID" });
            DropIndex("dbo.Branches", new[] { "CountryID" });
            DropIndex("dbo.Branches", new[] { "CityID" });
            DropTable("dbo.DeviceTypes");
            DropTable("dbo.Devices");
            DropTable("dbo.DeviceLocationInBranches");
            DropTable("dbo.ScheduleTypes");
            DropTable("dbo.ScheduleDetails");
            DropTable("dbo.Schedules");
            DropTable("dbo.EmployeeMobileNumbers");
            DropTable("dbo.Salaries");
            DropTable("dbo.EmployeePositions");
            DropTable("dbo.EmployeeDetails");
            DropTable("dbo.Employee");
            DropTable("dbo.Departments");
            DropTable("dbo.Currencies");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Branches");
        }
    }
}
