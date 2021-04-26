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
        public static GetEmployeeHolidayReqListItem AsViewModel(this EmployeeHolidayRequest model)
        {
            return new GetEmployeeHolidayReqListItem
            {
                ID = model.ID,
                AmountWorkDays = model.AmountWorkDays,
                FromDate = model.FromDate,
                HolidayTypeID = model.HolidayTypeID,
                RegistartionDate = model.RegistartionDate,
                ToDate = model.ToDate,
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
                UserIDInDevice = model.UserIDInDevice,
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
        public static Models.ViewModels.EmployeeHolidays AsViewModelEdit(this Models.EntityModels.EmployeeHolidays model)
        {
            return new Models.ViewModels.EmployeeHolidays()
            {
                ID=model.ID,
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
        public static Models.EntityModels.EmployeeHolidays AsDatabaseModel(this Models.ViewModels.EmployeeHolidays model)
        {
            return new Models.EntityModels.EmployeeHolidays()
            {
                ID=model.ID.HasValue?model.ID.Value:0,
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
        public static GetGovernmentHolidayListItem AsViewModel(this GovernmentHolidays model)
        {
            return new GetGovernmentHolidayListItem()
            {
                ID = model.ID,
                Description = model.Description,
                HolidayDate = model.HolidayDate
            };
        }
        public static GovernmentHolidays AsDatabaseModel(this AddGovernmentRequest model)
        {
            return new GovernmentHolidays()
            {
                Description=model.Description,
                 HolidayDate=model.HolidayDate
            };
        }
        public static GovernmentHolidays AsDatabaseModel(this EditGovernmentHolidayRequest model)
        {
            return new GovernmentHolidays()
            {
                ID=model.ID,
                Description = model.Description,
                HolidayDate = model.HolidayDate
            };
        }
        public static EmployeeHolidayRequest AsDatabaseModel(this EditEmployeeHolidayReqRequest model)
        {
            return new EmployeeHolidayRequest()
            {
                ID = model.ID,
                AmountWorkDays = model.AmountWorkDays,
                EmployeeID = model.EmployeeID,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                HolidayTypeID = model.HolidayTypeID,
                RegistartionDate = model.RegistartionDate

            };
        }
        public static EmployeeHolidayRequest AsDatabaseModel(this AddEmployeeHolidayReqRequest model)
        {
            return new EmployeeHolidayRequest()
            {
                AmountWorkDays = model.AmountWorkDays,
                EmployeeID = model.EmployeeID,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                HolidayTypeID = model.HolidayTypeID,
                RegistartionDate = model.RegistartionDate
            };
        }

        public static GetEmployeeForEdit EditViewModel(this Employee model)
        {
            return new GetEmployeeForEdit()
            {
                ID=model.ID,
                UserIDInDevice=model.UserIDInDevice,
                EmployeeDetailsID=model.EmployeeDetails.ID,
                AvatarImage=model.Avatar,
                Address = model.Address,
                Address_ka = model.Address_ka,
                Address_ru = model.Address_ru,
                BranchID = model.EmployeeDetails.BranchID,
                DateOfBirth = model.DateOfBirth,
                DepartmentID = model.EmployeeDetails.DepartmentID,
                DeviceCardID = model.DeviceCardID,
                Email = model.Email,
                EmployeePositionID = model.EmployeeDetails.EmployeePositionID,
                FirsName = model.FirsName,
                FirsName_ka = model.FirsName_ka,
                FirsName_ru = model.FirsName_ru,
                Fine = model.EmployeeDetails.Fine?.AsViewModel(),
                EmployeeHolidays = model.EmployeeHolidays.Select(m => m.AsViewModelEdit()).ToList(),
                GenderID = model.GenderID,
                LastName = model.LastName,
                LastName_ka = model.LastName_ka,
                LastName_ru = model.LastName_ru,
                IsActive = model.IsActive,
                Forgiveness = model.EmployeeDetails.Forgiveness.AsViewModel(),
                PersonalNumber = model.PersonalNumber,
                Salary = model.EmployeeDetails.Salary.AsViewModel(),
                Schedule = model.Schedule.AsViewModel()
            };
        }
        public static Employee AsDatabaseModel(this GetEmployeeForEdit model)
        {
            return new Employee()
            {
                ID=model.ID,
                
                Avatar =model.
                Address = model.Address,
                Address_ka = model.Address_ka,
                Address_ru = model.Address_ru,
                UserIDInDevice=model.UserIDInDevice,
                EmployeeDetails = new EmployeeDetails()
                {
                    ID=model.EmployeeDetailsID,
                    BranchID = model.BranchID,
                    DepartmentID = model.DepartmentID,
                    EmployeePositionID = model.EmployeePositionID,
                    Fine = model.Fine.AsDatabaseModel(),
                    Forgiveness = model.Forgiveness.AsDatabaseModel(),
                    Salary = model.Salary.AsDatabaseModel(),
                },

                DateOfBirth = model.DateOfBirth,
                DeviceCardID = model.DeviceCardID,
                Email = model.Email,
                FirsName = model.FirsName,
                FirsName_ka = model.FirsName_ka,
                FirsName_ru = model.FirsName_ru,
                EmployeeHolidays = model.EmployeeHolidays.Select(m=>m.AsDatabaseModel()).ToList(),
                GenderID = model.GenderID,
                LastName = model.LastName,
                LastName_ka = model.LastName_ka,
                LastName_ru = model.LastName_ru,
                IsActive = model.IsActive,
                
                PersonalNumber = model.PersonalNumber,
                
                Schedule = model.Schedule.AsDatabaseModel(),
            };
        }
        public static Models.ViewModels.ScheduleData AsViewModel(this Models.EntityModels.Schedule model)
        {
            return new Models.ViewModels.ScheduleData()
            {
                ID=model.ID,
                DaylyHouresAmount = model.DaylyHouresAmount,
                EndTime = model.EndTime,
                MinCheckInTime=model.MinCheckInTime,
                MaxCheckOutTime=model.MaxCheckOutTime,
                BreakAmount=model.BreakAmount,
                NotStandartSchedule = model.NotStandartSchedule,
                OnWorkingDaysOnly = model.OnWorkingDaysOnly,
                OnWorkingHouresOnly = model.OnWorkingHouresOnly,
                ScheduleTypeID = model.ScheduleTypeID,
                StartTime = model.StartTime,
                WeekHouresAmount = model.WeekHouresAmount
            };
        }
        public static SalaryData AsViewModel(this Salary model)
        {
            return new SalaryData()
            {
                ID=model.ID,
                Amount = model.Amount,
                CurrencyID = model.CurrencyID == 0 ? 1 : model.CurrencyID,
                IsHourly = model.IsHourly,
                SalaryTypeID = model.SalaryTypeID
            };
        }
        public static Models.ViewModels.Forgiveness AsViewModel(this Models.EntityModels.Forgiveness model)
        {
            return new Models.ViewModels.Forgiveness()
            {
                ID=model.ID,
                Amount = model.Amount,
                ForgivenessTypeID = model.ForgivenessTypeID,


            };
        }
        public static Models.ViewModels.Fine AsViewModel(this Models.EntityModels.Fine model)
        {
            return new Models.ViewModels.Fine()
            {
                ID=model.ID,
                Amount = model.Amount,
                FineTypeID = model.FineTypeID,
                CurrencyID = model.CurrencyID == 0 ? 1 : model.CurrencyID

            };
        }
        public static Employee AsDatabaseModel(this EditEmployeeRequestModel model)
        {
            return new Employee()
            {
                ID = model.ID,
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
                ScheduleID = model.Schedule.ID,

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
                MinCheckInTime=model.MinCheckInTime,
                MaxCheckOutTime=model.MaxCheckOutTime,
                BreakAmount=model.BreakAmount,
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
