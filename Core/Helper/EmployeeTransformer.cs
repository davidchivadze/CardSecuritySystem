using Models;
using Models.EntityModels;
using Models.ViewModels;
using Models.ViewModels.Employee;
using Models.ViewModels.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Helper
{
    public static class EmployeeTransformer
    {
        public static GetEmployeeHolidayListItem AsViewModel(this Models.EntityModels.EmployeeHolidays model)
        {
            return new GetEmployeeHolidayListItem
            {
                ID = model.ID,

                AllWritten = model.AllWritten,
                Used = model.Used,
                Left = model.Left,
                NumInYear = model.NumInYear,
                LeftInYear = model.LeftInYear,
                DeactivateDate = model.DeactivateDate,
                IsActive = model.IsActive,
                EmployeeID = model.EmployeeID
            };
        }
        public static GetEmployeeListItem AsViewModel(this Employee model)
        {
            return new GetEmployeeListItem
            {
                ID = model.ID,
                FirsName = model.FirsName,
                FirsName_ka = model.FirsName_ka,
                FirsName_ru = model.FirsName_ru,
                LastName = model.LastName,
                LastName_ka = model.LastName_ka,
                LastName_ru = model.LastName_ru,
                Country = model.EmployeeDetails.Branch.Country.Description,
                Address = model.Address,
                Address_ka = model.Address_ka,
                Address_ru = model.Address_ru,
                DateOfBirth = model.DateOfBirth,
                DeviceCardID = model.DeviceCardID,
                UserIDInDevice=model.UserIDInDevice,
                Email = model.Email,
                DepartmentName = model.EmployeeDetails.Department.Description,
                BranchName = model.EmployeeDetails.Branch.BranchName,
                Gender = model.Gender.Description,
                EmployeePosition = model.EmployeeDetails.Department.Description,
                IsActive = model.IsActive,
                Fine = model.EmployeeDetails.Fine.Amount,
                Forgiveness = model.EmployeeDetails.Forgiveness.Amount,
                PersonalNumber = model.PersonalNumber,
                Salary = model.EmployeeDetails.Salary.Amount,
                //MobileNumbers = model.EmployeeMobileNumbers?.Select(m => m.PhoneNumber.ToString()).ToArray()
            };
        }
        public static Models.EntityModels.EmployeeHolidays AsDatabaseModel(this Models.ViewModels.EmployeeHolidays model)
        {
            return new Models.EntityModels.EmployeeHolidays()
            {
                AllWritten = model.AllWritten,
                DeactivateDate = model.DeactivateDate,
                HolidayTypeID = model.HolidayTypeID,
                IsActive = model.IsActive,
                Left = model.Left,
                LeftInYear = model.LeftInYear,
                NumInYear = model.NumInYear,
                Used = model.Used,

            };
        }

        public static Employee AsDatabaseModel(this EditEmployeeRequestModel model)
        {
            return new Employee()
            {
                ID=model.ID,
                Address = model.Address,
                Address_ka = model.Address_ka ?? model.Address,
                Address_ru = model.Address_ru ?? model.Address,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                FirsName = model.FirsName,
                FirsName_ka = model.FirsName_ka ?? model.FirsName,
                FirsName_ru = model.FirsName_ru ?? model.FirsName,
                IsActive = true,
                LastName = model.LastName,
                LastName_ka = model.LastName_ka ?? model.LastName,
                LastName_ru = model.LastName_ru ?? model.LastName,
                GenderID = model.GenderID,
                DeviceCardID = model.DeviceCardID,
                PersonalNumber = model.PersonalNumber,
                ScheduleID=model.Schedule.ID,

                 //EmployeeMobileNumbers=model.MobileNumbers.FirstOrDefault()
                 
                

                EmployeeDetails = new EmployeeDetails()
                {
                    BranchID = model.BranchID,
                    DepartmentID = model.DepartmentID,
                    EmployeePositionID = model.EmployeePositionID,
                    Salary = model.Salary.AsDatabaseModel(),
                    Forgiveness = model.Forgiveness.AsDatabaseModel(),
                    Fine = model.Fine.AsDatabaseModel()
                },
                // EmployeeMobileNumbers = model.MobileNumbers.Select(m => new EmployeeMobileNumbers() { PhoneNumber = m, IsActive = true }).ToList(),
                Schedule = model.Schedule?.AsDatabaseModel(),
                EmployeeHolidays = model.EmployeeHolidays.Select(m => m.AsDatabaseModel()).ToList()


            };

        }
        public static Models.EntityModels.Salary AsDatabaseModel(this EditSalary model)
        {
            return new Models.EntityModels.Salary()
            {
                Amount = model.Amount,
                CurrencyID = model.CurrencyID == 0 ? 1 : model.CurrencyID,
                IsHourly = model.IsHourly,
                SalaryTypeID = model.SalaryTypeID
            };
        }
        public static Models.EntityModels.Schedule AsDatabaseModel(this Models.ViewModels.Employee.Schedule model)
        {
            return new Models.EntityModels.Schedule()
            {
                DaylyHouresAmount = model.DaylyHouresAmount,
                EndTime = model.EndTime,
                NotStandartSchedule = model.NotStandartSchedule,
                OnWorkingDaysOnly = model.OnWorkingDaysOnly,
                OnWorkingHouresOnly = model.OnWorkingHouresOnly,
                ScheduleTypeID = model.ScheduleTypeID,
                StartTime = model.StartTime,
                WeekHouresAmount = model.WeekHouresAmount
            };
        }
        public static Models.EntityModels.Forgiveness AsDatabaseModel(this EditForgiveness model)
        {
            return new Models.EntityModels.Forgiveness()
            {
                Amount = model.Amount,
                ForgivenessTypeID = model.ForgivenessTypeID

            };
        }
        public static Models.EntityModels.Fine AsDatabaseModel(this EditFine model)
        {
            return new Models.EntityModels.Fine()
            {
                Amount = model.Amount,
                FineTypeID = model.FineTypeID,
                CurrencyID = model.CurrencyID == 0 ? 1 : model.CurrencyID

            };
        }


    }
}
