﻿using Models;
using Models.EntityModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    public static class Transformer
    {
        public static Employee AsDatabaseModel(this AddEmployeeRequestModel model)
        {
            return new Employee()
            {
                Avatar=model.AvatarImage,
                UserIDInDevice=model.UserIdInDevice,
                Address = model.Address,
                Address_ka = model.Address_ka?? model.Address,
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
                DeviceCardID=model.DeviceCardID,
                PersonalNumber=model.PersonalNumber,
                
                EmployeeDetails = new EmployeeDetails()
                {
                    BranchID = model.BranchID==0?null:model.BranchID,
                    DepartmentID = model.DepartmentID==0?null:model.DepartmentID,
                    EmployeePositionID = model.EmployeePositionID==0?null:model.EmployeePositionID,
                    Salary = model.Salary.SalaryTypeID!=0?model.Salary.AsDatabaseModel():null,
                    Forgiveness = model.Forgiveness.ForgivenessTypeID!=0? model.Forgiveness.AsDatabaseModel():null,
                    Fine = model.Fine.FineTypeID!=0?model.Fine.AsDatabaseModel():null
                },
               // EmployeeMobileNumbers = model.MobileNumbers.Select(m => new EmployeeMobileNumbers() { PhoneNumber = m, IsActive = true }).ToList(),
                Schedule = model.Schedule?.AsDatabaseModel(),
                EmployeeHolidays=model.EmployeeHolidays.FirstOrDefault().HolidayTypeID!=0? model.EmployeeHolidays.Select(m=>m.AsDatabaseModel()).ToList():null
                
            
            };
        }


        //public static AddEmployeeRequestModel AsViewModel(this Employee model)
        //{
        //    return new AddEmployeeRequestModel()
        //    {
        //        Address = model.Address,
        //        Address_ka = model.Address_ka,
        //        Address_ru = model.Address_ru,
        //        BranchID = model.EmployeeDetails.BranchID,
        //        DateOfBirth = model.DateOfBirth,
        //        DepartmentID = model.EmployeeDetails.DepartmentID,
        //        Email = model.Email,
        //        EmployeePositionID = model.EmployeeDetails.EmployeePositionID,
        //        FirsName = model.FirsName,
        //        FirsName_ka = model.FirsName_ka,
        //        FirsName_ru = model.FirsName_ru,
        //        LastName = model.LastName,
        //        LastName_ka = model.LastName_ka,
        //        LastName_ru = model.LastName_ru,
        //        IsActive = model.IsActive,
        //        SalaryID = model.EmployeeDetails.SalaryID,
        //        MobileNumbers = model.EmployeeMobileNumbers.Select(m => m.PhoneNumber.ToString()).ToArray(),
               
                
        //    };
        //}
        public static Salary AsDatabaseModel(this SalaryData model)
        {
            return new Salary()
            {
                ID=model.ID.HasValue?model.ID.Value:0,
                Amount = model.Amount,
                CurrencyID = model.CurrencyID==0?1:model.CurrencyID,
                IsHourly = model.IsHourly,
                SalaryTypeID = model.SalaryTypeID
            };
        }
        public static Schedule AsDatabaseModel(this ScheduleData model)
        {
            return new Schedule()
            {
                ID=model.ID.HasValue?model.ID.Value:0,
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
        public static Models.EntityModels.Forgiveness AsDatabaseModel(this Models.ViewModels.Forgiveness model) {
            return new Models.EntityModels.Forgiveness()
            {
                ID=model.ID.HasValue?model.ID.Value:0,
                Amount = model.Amount,
                ForgivenessTypeID = model.ForgivenessTypeID

            };
        }
        public static Models.EntityModels.Fine AsDatabaseModel(this Models.ViewModels.Fine model)
        {
            return new Models.EntityModels.Fine()
            {
                ID=model.ID.HasValue?model.ID.Value:0,
                Amount = model.Amount,
                FineTypeID = model.FineTypeID,
                 CurrencyID=model.CurrencyID==0?1:model.CurrencyID

            };
        }

        public static Branch AsDataBaseModel(this BranchViewModel model)
        {
            return new Branch()
            {
                Address = model.Address,
                BranchName = model.BranchName,
                CityID = model.CityID,
                CountryID = model.CountryID,
                //Devices = model.Devices,
            };
        }

        public static BranchViewModel AsViewModel(this Branch model) 
        {
            return new BranchViewModel()
            {
                Address = model.Address,
                CityID = model.CityID,
                CountryID = model.CountryID,
                BranchName = model.BranchName,
                //Devices = model.Devices.ToList()
            };
        }

        public static City AsDatabaseModel(this CityViewModel model)
        {
            return new City()
            {
                Description = model.Description,
                Description_ka = model.Description,
                Description_ru = model.Description_ru
            };
        }

        public static CityViewModel AsViewModel(this City model)
        {
            return new CityViewModel()
            {
                Description = model.Description,
                Description_ka = model.Description,
                Description_ru = model.Description_ru
            };
        }

        public static Country AsDatabaseModel(this CountryViewModel model)
        {
            return new Country()
            {
                Description = model.Description,
                Description_ka = model.Description,
                Description_ru = model.Description_ru
            };
        }

        public static CountryViewModel AsViewModel(this Country model)
        {
            return new CountryViewModel()
            {
                Description = model.Description,
                Description_ka = model.Description,
                Description_ru = model.Description_ru
            };
        }

        public static Currency AsDatabaseModel(this CurrencyViewModel model)
        {
            return new Currency()
            {
                Description = model.Description,
                Description_ka = model.Description,
                Description_ru = model.Description_ru
            };
        }

        public static CurrencyViewModel AsViewModel(this Currency model)
        {
            return new CurrencyViewModel()
            {
                Description = model.Description,
                Description_ka = model.Description,
                Description_ru = model.Description_ru
            };
        }
    }
}
