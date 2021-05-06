namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.Employee", "ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.EmployeeDetails", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.EmployeeDetails", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.EmployeeDetails", "EmployeePositionID", "dbo.EmployeePositions");
            DropForeignKey("dbo.EmployeeDetails", "FineID", "dbo.Fines");
            DropForeignKey("dbo.EmployeeDetails", "ForgivenessID", "dbo.Forgivenesses");
            DropForeignKey("dbo.EmployeeDetails", "SalaryID", "dbo.Salaries");
            DropIndex("dbo.Employee", new[] { "ScheduleID" });
            DropIndex("dbo.Employee", new[] { "GenderID" });
            DropIndex("dbo.EmployeeDetails", new[] { "EmployeePositionID" });
            DropIndex("dbo.EmployeeDetails", new[] { "SalaryID" });
            DropIndex("dbo.EmployeeDetails", new[] { "BranchID" });
            DropIndex("dbo.EmployeeDetails", new[] { "DepartmentID" });
            DropIndex("dbo.EmployeeDetails", new[] { "FineID" });
            DropIndex("dbo.EmployeeDetails", new[] { "ForgivenessID" });
            AlterColumn("dbo.Employee", "ScheduleID", c => c.Int());
            AlterColumn("dbo.Employee", "GenderID", c => c.Int());
            AlterColumn("dbo.EmployeeDetails", "EmployeeID", c => c.Int());
            AlterColumn("dbo.EmployeeDetails", "EmployeePositionID", c => c.Int());
            AlterColumn("dbo.EmployeeDetails", "SalaryID", c => c.Int());
            AlterColumn("dbo.EmployeeDetails", "BranchID", c => c.Int());
            AlterColumn("dbo.EmployeeDetails", "DepartmentID", c => c.Int());
            AlterColumn("dbo.EmployeeDetails", "FineID", c => c.Int());
            AlterColumn("dbo.EmployeeDetails", "ForgivenessID", c => c.Int());
            AlterColumn("dbo.Employee", "DateOfBirth", c => c.DateTime(nullable: true));
            CreateIndex("dbo.Employee", "ScheduleID");
            CreateIndex("dbo.Employee", "GenderID");
            CreateIndex("dbo.EmployeeDetails", "EmployeePositionID");
            CreateIndex("dbo.EmployeeDetails", "SalaryID");
            CreateIndex("dbo.EmployeeDetails", "BranchID");
            CreateIndex("dbo.EmployeeDetails", "DepartmentID");
            CreateIndex("dbo.EmployeeDetails", "FineID");
            CreateIndex("dbo.EmployeeDetails", "ForgivenessID");
            AddForeignKey("dbo.Employee", "GenderID", "dbo.Genders", "ID");
            AddForeignKey("dbo.Employee", "ScheduleID", "dbo.Schedules", "ID");
            AddForeignKey("dbo.EmployeeDetails", "BranchID", "dbo.Branches", "ID");
            AddForeignKey("dbo.EmployeeDetails", "DepartmentID", "dbo.Departments", "ID");
            AddForeignKey("dbo.EmployeeDetails", "EmployeePositionID", "dbo.EmployeePositions", "ID");
            AddForeignKey("dbo.EmployeeDetails", "FineID", "dbo.Fines", "ID");
            AddForeignKey("dbo.EmployeeDetails", "ForgivenessID", "dbo.Forgivenesses", "ID");
            AddForeignKey("dbo.EmployeeDetails", "SalaryID", "dbo.Salaries", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeDetails", "SalaryID", "dbo.Salaries");
            DropForeignKey("dbo.EmployeeDetails", "ForgivenessID", "dbo.Forgivenesses");
            DropForeignKey("dbo.EmployeeDetails", "FineID", "dbo.Fines");
            DropForeignKey("dbo.EmployeeDetails", "EmployeePositionID", "dbo.EmployeePositions");
            DropForeignKey("dbo.EmployeeDetails", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.EmployeeDetails", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.Employee", "ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Employee", "GenderID", "dbo.Genders");
            DropIndex("dbo.EmployeeDetails", new[] { "ForgivenessID" });
            DropIndex("dbo.EmployeeDetails", new[] { "FineID" });
            DropIndex("dbo.EmployeeDetails", new[] { "DepartmentID" });
            DropIndex("dbo.EmployeeDetails", new[] { "BranchID" });
            DropIndex("dbo.EmployeeDetails", new[] { "SalaryID" });
            DropIndex("dbo.EmployeeDetails", new[] { "EmployeePositionID" });
            DropIndex("dbo.Employee", new[] { "GenderID" });
            DropIndex("dbo.Employee", new[] { "ScheduleID" });
            AlterColumn("dbo.EmployeeDetails", "ForgivenessID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeDetails", "FineID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeDetails", "DepartmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeDetails", "BranchID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeDetails", "SalaryID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeDetails", "EmployeePositionID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeDetails", "EmployeeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "GenderID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "ScheduleID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "DateOfBirth", c => c.DateTime(nullable: false));
            CreateIndex("dbo.EmployeeDetails", "ForgivenessID");
            CreateIndex("dbo.EmployeeDetails", "FineID");
            CreateIndex("dbo.EmployeeDetails", "DepartmentID");
            CreateIndex("dbo.EmployeeDetails", "BranchID");
            CreateIndex("dbo.EmployeeDetails", "SalaryID");
            CreateIndex("dbo.EmployeeDetails", "EmployeePositionID");
            CreateIndex("dbo.Employee", "GenderID");
            CreateIndex("dbo.Employee", "ScheduleID");
            AddForeignKey("dbo.EmployeeDetails", "SalaryID", "dbo.Salaries", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeDetails", "ForgivenessID", "dbo.Forgivenesses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeDetails", "FineID", "dbo.Fines", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeDetails", "EmployeePositionID", "dbo.EmployeePositions", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeDetails", "DepartmentID", "dbo.Departments", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeDetails", "BranchID", "dbo.Branches", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Employee", "ScheduleID", "dbo.Schedules", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Employee", "GenderID", "dbo.Genders", "ID", cascadeDelete: true);
        }
    }
}
