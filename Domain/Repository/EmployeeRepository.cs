using Domain.Interface;
using Models;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helper.RepositoryHelperClasses;
using System.Data.Entity.Migrations;
using Models.EntityModels.StoredProcedures;
using System.Data.SqlClient;

namespace Domain.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Data database) : base(database) { }

        public IEnumerable<Employee> GetFilteredEmployees(EmployeeFilter filterModel)
        {
            return _database.Employees.Include("EmployeeDetails").Include("EmployeeDetails.Branch").Where(e => (filterModel.IsActive.HasValue ? e.IsActive == filterModel.IsActive.Value : e.IsActive == e.IsActive)
                                               && (filterModel.BranchID.HasValue ? e.EmployeeDetails.BranchID == filterModel.BranchID.Value : e.EmployeeDetails.BranchID == e.EmployeeDetails.BranchID)
                                               && (filterModel.DepartmentID.HasValue ? e.EmployeeDetails.BranchID == filterModel.DepartmentID.Value : e.EmployeeDetails.DepartmentID == e.EmployeeDetails.DepartmentID)).Where(m => m.IsActive);
        }
        public Employee AddEmployee(Employee addModel)
        {
            var result = _database.Employees.Add(addModel);
            _database.SaveChanges();
            return result;
        }

        public Employee UpdateEmployeeSyncData(int deviceUserID, int userID)
        {
            var editUser = _database.Employees.Where(m => m.ID == userID).FirstOrDefault();
            editUser.UserIDInDevice = deviceUserID;
            _database.SaveChanges();
            return editUser;
        }

        public bool DeleteEmployee(int employeeID)
        {
            var result = _database.Employees.Where(m => m.ID == employeeID).FirstOrDefault();
            result.IsActive = false;
            _database.SaveChanges();
            return true;
        }

        public Employee EditEmployee(Employee EditModel)
        {
            var EditEmployee = _database.Employees
               .Include("EmployeeDetails")
                //.Include("EmployeeDetails.Branch").Include("EmployeeDetails.Branch.Country").Include("EmployeeDetails.Branch.Devices").Include("EmployeeDetails.Branch.City").Include("EmployeeDetails.Branch.Devices").Include("EmployeeDetails.Branch.DeviceLocationInBranches").Include("EmployeeDetails.Branch.Country").Include("EmployeeDetails.Branch.City").Include("EmployeeDetails.Branch.Country.Cities")
                .Include("EmployeeDetails.Salary")//.Include("EmployeeDetails.Salary.SalaryType").Include("EmployeeDetails.Salary.Currency")
                .Include("EmployeeDetails.Fine")//.Include("EmployeeDetails.Fine.FineType").Include("EmployeeDetails.Fine.Currency")
                                                //.Include("EmployeeDetails.Department").Include("EmployeeDetails.ParentDepartment")
                .Include("EmployeeDetails.Forgiveness")//.Include("EmployeeDetails.Forgiveness.ForgivenessType")
                                                       //.Include("EmployeeDetails.EmployeePosition")
                                                       //.Include("Gender")
                                                       //.Include("EmployeeMobileNumbers")
                .Include("EmployeeHolidays")//.Include("EmployeeHolidays.HolidayType")
                .Include("Schedule")//.Include("Schedule.ScheduleType").Include("Schedule.ScheduleDetails")
                .Where(m => m.ID == EditModel.ID).FirstOrDefault();
            //schedule
            EditEmployee.EmployeeDetails.Salary.Amount = EditModel.EmployeeDetails.Salary.Amount;
            EditEmployee.EmployeeDetails.Salary.SalaryTypeID = EditModel.EmployeeDetails.Salary.SalaryTypeID;
            EditEmployee.EmployeeDetails.Fine.FineTypeID = EditModel.EmployeeDetails.Fine.FineTypeID;
            EditEmployee.EmployeeDetails.Fine.Amount = EditModel.EmployeeDetails.Fine.Amount;
            EditEmployee.EmployeeDetails.Forgiveness.Amount = EditModel.EmployeeDetails.Forgiveness.Amount;
            EditEmployee.EmployeeDetails.Forgiveness.ForgivenessTypeID= EditModel.EmployeeDetails.Forgiveness.ForgivenessTypeID;
            EditEmployee.Schedule.EndTime = EditModel.Schedule.EndTime;
            EditEmployee.Schedule.DaylyHouresAmount = EditModel.Schedule.DaylyHouresAmount;
            EditEmployee.Schedule.MinCheckInTime = EditModel.Schedule.MinCheckInTime;
            EditEmployee.Schedule.MaxCheckOutTime = EditModel.Schedule.MaxCheckOutTime;
            EditEmployee.Schedule.BreakAmount = EditEmployee.Schedule.BreakAmount;
            EditEmployee.Schedule.IsActive = EditModel.Schedule.IsActive;
            EditEmployee.Schedule.NotStandartSchedule = EditModel.Schedule.NotStandartSchedule;
            EditEmployee.Schedule.OnWorkingDaysOnly = EditModel.Schedule.OnWorkingDaysOnly;
            EditEmployee.Schedule.OnWorkingHouresOnly = EditModel.Schedule.OnWorkingHouresOnly;
            EditEmployee.Schedule.ScheduleTypeID = EditModel.Schedule.ScheduleTypeID;
            EditEmployee.Schedule.WeekHouresAmount = EditModel.Schedule.WeekHouresAmount;
            EditEmployee.EmployeeDetails.BranchID = EditModel.EmployeeDetails.BranchID;
            EditEmployee.EmployeeDetails.DepartmentID = EditModel.EmployeeDetails.DepartmentID;
            EditEmployee.EmployeeDetails.EmployeePositionID = EditModel.EmployeeDetails.EmployeePositionID;
            EditEmployee.UserIDInDevice = EditModel.UserIDInDevice;
            EditEmployee.PersonalNumber = EditModel.PersonalNumber;
            EditEmployee.IsActive = EditModel.IsActive;
            EditEmployee.FirsName = EditModel.FirsName;
            EditEmployee.LastName = EditModel.LastName;
            EditEmployee.LastName_ka = EditModel.LastName_ka;
            EditEmployee.LastName_ru = EditModel.LastName_ru;
            EditEmployee.FirsName_ka = EditModel.FirsName_ka;
            EditEmployee.FirsName_ru = EditModel.FirsName_ru;
            EditEmployee.GenderID = EditModel.GenderID;
            EditEmployee.Email = EditModel.Email;
            EditEmployee.DateOfBirth = EditModel.DateOfBirth;
            EditEmployee.Address = EditModel.Address;
            EditEmployee.Address_ka = EditModel.Address_ka;
            EditEmployee.Address_ru = EditModel.Address_ru;
            foreach (var holiday in EditModel.EmployeeHolidays)
            {
                EditEmployee.EmployeeHolidays.Where(m => m.ID == holiday.ID).FirstOrDefault().HolidayTypeID = holiday.HolidayTypeID;
                EditEmployee.EmployeeHolidays.Where(m => m.ID == holiday.ID).FirstOrDefault().AllWritten = holiday.AllWritten;

                EditEmployee.EmployeeHolidays.Where(m => m.ID == holiday.ID).FirstOrDefault().NumInYear = holiday.NumInYear;
                EditEmployee.EmployeeHolidays.Where(m => m.ID == holiday.ID).FirstOrDefault().LeftInYear = holiday.LeftInYear;
            }

            _database.Entry<Employee>(EditEmployee).State = System.Data.Entity.EntityState.Modified;
            _database.SaveChanges();
            return EditEmployee;

        }


        public ICollection<EmployeeMODReport> GetEmployeeMODReport(DateTime DateFrom, DateTime DateTo, int? EmployeeID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StartDate",DateFrom),
                new SqlParameter("@EndDate",DateTo)
            };
            var result = _database.Database.SqlQuery<EmployeeMODReport>("EXEC dbo.GenerateMODReport @StartDate,@EndDate", parameters).ToList();
            return result;
        }
        public ICollection<EmploeeFullReport> GetEmployeeFullReport(DateTime DateFrom, DateTime DateTo, int? EmployeeID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StartDate",DateFrom),
                new SqlParameter("@EndDate",DateTo)
            };
            var result = _database.Database.SqlQuery<EmploeeFullReport>("EXEC dbo.GenerateFullReport @StartDate,@EndDate", parameters).ToList();
            return result;
        }
        public Employee GetEmployeeForEdit(int EmployeeID)
        {

            return _database.Employees.Include("EmployeeDetails").Include("EmployeeHolidays").Include("Gender").Include("Schedule").Where(m => m.ID == EmployeeID).FirstOrDefault();
        }

        public Employee GetEmployeeSchedule(int EmployeeID)
        {
            return _database.Employees.Include("EmployeeDetails").Include("EmployeeHolidays").Include("Gender").Include("Schedule").Where(m => m.ID == EmployeeID).FirstOrDefault();
        }

        public bool GenerateModReportData(DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                  {
                              new SqlParameter("@StartDate",DateFrom),
                              new SqlParameter("@EndDate",DateTo)
                  };
                var result = _database.Database.ExecuteSqlCommand("EXEC [dbo].[GenerateMODReportData] @StartDate,@EndDate", parameters);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "  " + ex.InnerException?.Message);
            }


        }
    }
}
