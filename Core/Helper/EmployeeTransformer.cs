using Models;
using Models.EntityModels;
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
        public static GetEmployeeHolidayListItem AsViewModel(this EmployeeHolidays model)
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
        public static EmployeeHolidays AsDatabaseModel(this Models.ViewModels.EmployeeHolidays model)
        {
            return new EmployeeHolidays()
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

    }
}
