namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixMigrationsLoss : DbMigration
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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: false)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: false)
                .Index(t => t.CityID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountryID = c.Int(nullable: false),
                        Description = c.String(),
                        Description_ka = c.String(),
                        Description_ru = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: false)
                .Index(t => t.CountryID);
            
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
                .ForeignKey("dbo.Branches", t => t.BranchID, cascadeDelete: false)
                .ForeignKey("dbo.DeviceLocationInBranches", t => t.DeviceLocationInBranchID, cascadeDelete: false)
                .ForeignKey("dbo.DeviceTypes", t => t.DeviceTypeID, cascadeDelete: false)
                .Index(t => t.DeviceTypeID)
                .Index(t => t.BranchID)
                .Index(t => t.DeviceLocationInBranchID);
            
            CreateTable(
                "dbo.DeviceLocationInBranches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DeviceTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.ParentDepartmentID)
                .Index(t => t.ParentDepartmentID);
            
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
                        GenderID = c.Int(nullable: false),
                        EmployeeDetails_ID = c.Int(),
                        Departments_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeeDetails", t => t.EmployeeDetails_ID)
                .ForeignKey("dbo.Genders", t => t.GenderID, cascadeDelete: false)
                .ForeignKey("dbo.Schedules", t => t.ScheduleID, cascadeDelete: false)
                .ForeignKey("dbo.Departments", t => t.Departments_ID)
                .Index(t => t.ScheduleID)
                .Index(t => t.GenderID)
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
                        FineID = c.Int(nullable: false),
                        ForgivenessID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Branches", t => t.BranchID, cascadeDelete: false)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: false)
                .ForeignKey("dbo.EmployeePositions", t => t.EmployeePositionID, cascadeDelete: false)
                .ForeignKey("dbo.Fines", t => t.FineID, cascadeDelete: false)
                .ForeignKey("dbo.Forgivenesses", t => t.ForgivenessID, cascadeDelete: false)
                .ForeignKey("dbo.Salaries", t => t.SalaryID, cascadeDelete: false)
                .Index(t => t.EmployeePositionID)
                .Index(t => t.SalaryID)
                .Index(t => t.BranchID)
                .Index(t => t.DepartmentID)
                .Index(t => t.FineID)
                .Index(t => t.ForgivenessID);
            
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
                "dbo.Fines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        FineTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Currencies", t => t.CurrencyID, cascadeDelete: false)
                .ForeignKey("dbo.FineTypes", t => t.FineTypeID, cascadeDelete: false)
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
            
            CreateTable(
                "dbo.Forgivenesses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ForgivenessTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ForgivenessTypes", t => t.ForgivenessTypeID, cascadeDelete: false)
                .Index(t => t.ForgivenessTypeID);
            
            CreateTable(
                "dbo.ForgivenessTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        SalaryTypeID = c.Int(nullable: false),
                        IsHourly = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Currencies", t => t.CurrencyID, cascadeDelete: false)
                .ForeignKey("dbo.SalaryTypes", t => t.SalaryTypeID, cascadeDelete: false)
                .Index(t => t.CurrencyID)
                .Index(t => t.SalaryTypeID);
            
            CreateTable(
                "dbo.SalaryTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmployeeHolidays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AllWritten = c.String(),
                        Left = c.String(),
                        Used = c.String(),
                        NumInYear = c.String(),
                        LeftInYear = c.String(),
                        DeactivateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: false)
                .Index(t => t.EmployeeID);
            
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
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: false)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ScheduleTypes", t => t.ScheduleTypeID, cascadeDelete: false)
                .Index(t => t.ScheduleTypeID);
            
            CreateTable(
                "dbo.ScheduleDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        HasPassed = c.Boolean(nullable: false),
                        ScheduleID = c.Int(nullable: false),
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
                "dbo.DeviceRegistratedUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserDeviceID = c.Int(nullable: false),
                        MachineNumber = c.Int(nullable: false),
                        Name = c.String(),
                        FingerIndex = c.Int(nullable: false),
                        TmpData = c.String(),
                        Privelage = c.Int(nullable: false),
                        Password = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        iFlag = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DeviceUserLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MachineNumber = c.Int(nullable: false),
                        IndRegID = c.Int(nullable: false),
                        dwVerifyMode = c.Int(nullable: false),
                        dwInOutMode = c.Int(nullable: false),
                        DateTimeRecord = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ScheduleDetailsSchedules",
                c => new
                    {
                        ScheduleDetails_ID = c.Int(nullable: false),
                        Schedule_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ScheduleDetails_ID, t.Schedule_ID })
                .ForeignKey("dbo.ScheduleDetails", t => t.ScheduleDetails_ID, cascadeDelete: false)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ID, cascadeDelete: false)
                .Index(t => t.ScheduleDetails_ID)
                .Index(t => t.Schedule_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "ParentDepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Employee", "Departments_ID", "dbo.Departments");
            DropForeignKey("dbo.Employee", "ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "ScheduleTypeID", "dbo.ScheduleTypes");
            DropForeignKey("dbo.ScheduleDetailsSchedules", "Schedule_ID", "dbo.Schedules");
            DropForeignKey("dbo.ScheduleDetailsSchedules", "ScheduleDetails_ID", "dbo.ScheduleDetails");
            DropForeignKey("dbo.Employee", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.EmployeeMobileNumbers", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.EmployeeHolidays", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.EmployeeDetails", "SalaryID", "dbo.Salaries");
            DropForeignKey("dbo.Salaries", "SalaryTypeID", "dbo.SalaryTypes");
            DropForeignKey("dbo.Salaries", "CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.EmployeeDetails", "ForgivenessID", "dbo.Forgivenesses");
            DropForeignKey("dbo.Forgivenesses", "ForgivenessTypeID", "dbo.ForgivenessTypes");
            DropForeignKey("dbo.EmployeeDetails", "FineID", "dbo.Fines");
            DropForeignKey("dbo.Fines", "FineTypeID", "dbo.FineTypes");
            DropForeignKey("dbo.Fines", "CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.EmployeeDetails", "EmployeePositionID", "dbo.EmployeePositions");
            DropForeignKey("dbo.Employee", "EmployeeDetails_ID", "dbo.EmployeeDetails");
            DropForeignKey("dbo.EmployeeDetails", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.EmployeeDetails", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.Devices", "DeviceTypeID", "dbo.DeviceTypes");
            DropForeignKey("dbo.Devices", "DeviceLocationInBranchID", "dbo.DeviceLocationInBranches");
            DropForeignKey("dbo.Devices", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.Branches", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Branches", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryID", "dbo.Countries");
            DropIndex("dbo.ScheduleDetailsSchedules", new[] { "Schedule_ID" });
            DropIndex("dbo.ScheduleDetailsSchedules", new[] { "ScheduleDetails_ID" });
            DropIndex("dbo.Schedules", new[] { "ScheduleTypeID" });
            DropIndex("dbo.EmployeeMobileNumbers", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeHolidays", new[] { "EmployeeID" });
            DropIndex("dbo.Salaries", new[] { "SalaryTypeID" });
            DropIndex("dbo.Salaries", new[] { "CurrencyID" });
            DropIndex("dbo.Forgivenesses", new[] { "ForgivenessTypeID" });
            DropIndex("dbo.Fines", new[] { "FineTypeID" });
            DropIndex("dbo.Fines", new[] { "CurrencyID" });
            DropIndex("dbo.EmployeeDetails", new[] { "ForgivenessID" });
            DropIndex("dbo.EmployeeDetails", new[] { "FineID" });
            DropIndex("dbo.EmployeeDetails", new[] { "DepartmentID" });
            DropIndex("dbo.EmployeeDetails", new[] { "BranchID" });
            DropIndex("dbo.EmployeeDetails", new[] { "SalaryID" });
            DropIndex("dbo.EmployeeDetails", new[] { "EmployeePositionID" });
            DropIndex("dbo.Employee", new[] { "Departments_ID" });
            DropIndex("dbo.Employee", new[] { "EmployeeDetails_ID" });
            DropIndex("dbo.Employee", new[] { "GenderID" });
            DropIndex("dbo.Employee", new[] { "ScheduleID" });
            DropIndex("dbo.Departments", new[] { "ParentDepartmentID" });
            DropIndex("dbo.Devices", new[] { "DeviceLocationInBranchID" });
            DropIndex("dbo.Devices", new[] { "BranchID" });
            DropIndex("dbo.Devices", new[] { "DeviceTypeID" });
            DropIndex("dbo.Cities", new[] { "CountryID" });
            DropIndex("dbo.Branches", new[] { "CountryID" });
            DropIndex("dbo.Branches", new[] { "CityID" });
            DropTable("dbo.ScheduleDetailsSchedules");
            DropTable("dbo.DeviceUserLogs");
            DropTable("dbo.DeviceRegistratedUsers");
            DropTable("dbo.ScheduleTypes");
            DropTable("dbo.ScheduleDetails");
            DropTable("dbo.Schedules");
            DropTable("dbo.Genders");
            DropTable("dbo.EmployeeMobileNumbers");
            DropTable("dbo.EmployeeHolidays");
            DropTable("dbo.SalaryTypes");
            DropTable("dbo.Salaries");
            DropTable("dbo.ForgivenessTypes");
            DropTable("dbo.Forgivenesses");
            DropTable("dbo.FineTypes");
            DropTable("dbo.Fines");
            DropTable("dbo.EmployeePositions");
            DropTable("dbo.EmployeeDetails");
            DropTable("dbo.Employee");
            DropTable("dbo.Departments");
            DropTable("dbo.Currencies");
            DropTable("dbo.DeviceTypes");
            DropTable("dbo.DeviceLocationInBranches");
            DropTable("dbo.Devices");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Branches");
        }
    }
}
