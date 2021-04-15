using Domain.Interface;
using Models;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helper.RepositoryHelperClasses;

namespace Domain.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Data database):base(database){}

        public IEnumerable<Employee> GetFilteredEmployees(EmployeeFilter filterModel)
        {
            return _database.Employees.Include("EmployeeDetails").Include("EmployeeDetails.Branch").Where(e => (filterModel.IsActive.HasValue ? e.IsActive == filterModel.IsActive.Value : e.IsActive == e.IsActive)
                                               && (filterModel.BranchID.HasValue ? e.EmployeeDetails.BranchID == filterModel.BranchID.Value : e.EmployeeDetails.BranchID == e.EmployeeDetails.BranchID)
                                               && (filterModel.DepartmentID.HasValue ? e.EmployeeDetails.BranchID == filterModel.DepartmentID.Value : e.EmployeeDetails.DepartmentID == e.EmployeeDetails.DepartmentID)).Where(m=>m.IsActive);
        }
        public Employee AddEmployee(Employee addModel)
        {
            var result= _database.Employees.Add(addModel);
            _database.SaveChanges();
            return result;
        }

        public Employee UpdateEmployeeSyncData(int deviceUserID,int userID)
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
            var result = _database.Employees
                .Include("EmployeeDetails")
                .Include("EmployeeDetails.Branch").Include("EmployeeDetails.Branch.Country").Include("EmployeeDetails.Branch.Devices").Include("EmployeeDetails.Branch.City").Include("EmployeeDetails.Branch.Devices").Include("EmployeeDetails.Branch.DeviceLocationInBranches").Include("EmployeeDetails.Branch.Country").Include("EmployeeDetails.Branch.City").Include("EmployeeDetails.Branch.Country.Cities")
                .Include("EmployeeDetails.Salary").Include("EmployeeDetails.Salary.SalaryType").Include("EmployeeDetails.Salary.Currency")
                .Include("EmployeeDetails.Fine").Include("EmployeeDetails.Fine.FineType").Include("EmployeeDetails.Fine.Currency")
                .Include("EmployeeDetails.Department").Include("EmployeeDetails.ParentDepartment")
                .Include("EmployeeDetails.Forgiveness").Include("EmployeeDetails.Forgiveness.ForgivenessType")
                .Include("EmployeeDetails.EmployeePosition")
                .Include("Gender")
                .Include("EmployeeMobileNumbers")
                .Include("EmployeeHolidays").Include("EmployeeHolidays.HolidayType")
                .Include("Schedule").Include("Schedule.ScheduleType").Include("Schedule.ScheduleDetails")
                .Where(m => m.ID == EditModel.ID).FirstOrDefault();
            result.Address = EditModel.Address;
            result.Address_ka = EditModel.Address_ka;
            result.Address_ru = EditModel.Address_ru;
            result.DateOfBirth = EditModel.DateOfBirth;
            result.DeviceCardID = EditModel.DeviceCardID;
            result.Email = EditModel.Email;
            result.FirsName = EditModel.FirsName;
            result.FirsName_ka = EditModel.FirsName_ka;
            result.FirsName_ru = EditModel.FirsName_ru;
            result.GenderID = EditModel.GenderID;
            result.IsActive = EditModel.IsActive;
            result.LastName = EditModel.LastName;
            result.LastName_ka = EditModel.LastName_ka;
            result.LastName_ru = EditModel.LastName_ru;
            result.PersonalNumber = EditModel.PersonalNumber;
            result.ScheduleID = EditModel.ScheduleID;
            result.UserIDInDevice = EditModel.UserIDInDevice;

            result.EmployeeDetails = new EmployeeDetails()
            {
                BranchID = EditModel.EmployeeDetails.BranchID,
                DepartmentID = EditModel.EmployeeDetails.DepartmentID,
                EmployeeID = EditModel.EmployeeDetails.EmployeeID,
                EmployeePositionID = EditModel.EmployeeDetails.EmployeePositionID,
                FineID = EditModel.EmployeeDetails.FineID,
                ForgivenessID = EditModel.EmployeeDetails.ForgivenessID,
                ID = EditModel.EmployeeDetails.ID,
                SalaryID = EditModel.EmployeeDetails.SalaryID,
                Branch = new Branch()
                {
                    ID = EditModel.EmployeeDetails.Branch.ID,
                    Address = EditModel.EmployeeDetails.Branch.Address,
                    BranchName = EditModel.EmployeeDetails.Branch.BranchName,
                    CityID = EditModel.EmployeeDetails.Branch.CityID,
                    CountryID = EditModel.EmployeeDetails.Branch.CountryID,
                    IsActive = EditModel.EmployeeDetails.Branch.IsActive,
                    City = new City()
                    {
                        ID = EditModel.EmployeeDetails.Branch.City.ID,
                        CountryID = EditModel.EmployeeDetails.Branch.City.CountryID,
                        Description = EditModel.EmployeeDetails.Branch.City.Description,
                        Description_ka = EditModel.EmployeeDetails.Branch.City.Description_ka,
                        Description_ru = EditModel.EmployeeDetails.Branch.City.Description_ru,
                        Country = new Country()
                        {
                            Description = EditModel.EmployeeDetails.Branch.City.Country.Description,
                            Description_ka = EditModel.EmployeeDetails.Branch.City.Country.Description_ka,
                            Description_ru = EditModel.EmployeeDetails.Branch.City.Country.Description_ru,
                            ID = EditModel.EmployeeDetails.Branch.City.Country.ID
                        }
                    },
                    Country = new Country()
                    {
                        ID = EditModel.EmployeeDetails.Branch.Country.ID,
                        Description = EditModel.EmployeeDetails.Branch.Country.Description,
                        Description_ka = EditModel.EmployeeDetails.Branch.Country.Description_ka,
                        Description_ru = EditModel.EmployeeDetails.Branch.Country.Description_ru,
                        Cities = new List<City>()
                        {
                            new City()
                            {
                                 ID=EditModel.EmployeeDetails.Branch.Country.Cities.FirstOrDefault().ID,
                                 Description=EditModel.EmployeeDetails.Branch.Country.Cities.FirstOrDefault().Description,
                                 Description_ka=EditModel.EmployeeDetails.Branch.Country.Cities.FirstOrDefault().Description_ka,
                                 Description_ru=EditModel.EmployeeDetails.Branch.Country.Cities.FirstOrDefault().Description_ru,
                                 CountryID=EditModel.EmployeeDetails.Branch.Country.Cities.FirstOrDefault().CountryID
                            }
                        }
                    }
                },
                EmployeePosition = new EmployeePosition()
                {
                    ID = EditModel.EmployeeDetails.EmployeePosition.ID,
                    Description = EditModel.EmployeeDetails.EmployeePosition.Description,
                    Description_ka = EditModel.EmployeeDetails.EmployeePosition.Description_ka,
                    Description_ru = EditModel.EmployeeDetails.EmployeePosition.Description_ru,
                    IsActive = EditModel.EmployeeDetails.EmployeePosition.IsActive
                },
                Department = new Departments()
                {
                    ID = EditModel.EmployeeDetails.Department.ID,
                    Description = EditModel.EmployeeDetails.Department.Description,
                    Description_ka = EditModel.EmployeeDetails.Department.Description_ka,
                    Description_ru = EditModel.EmployeeDetails.Department.Description_ru,
                    IsActive = EditModel.EmployeeDetails.Department.IsActive,
                    ParentDepartmentID = EditModel.EmployeeDetails.Department.ParentDepartmentID

                },
                Fine = new Fine()
                {
                    ID = EditModel.EmployeeDetails.Fine.ID,
                    Amount = EditModel.EmployeeDetails.Fine.Amount,
                    CurrencyID = EditModel.EmployeeDetails.Fine.CurrencyID,
                    FineTypeID = EditModel.EmployeeDetails.Fine.FineTypeID,
                    Currency = new Currency()
                    {
                        ID = EditModel.EmployeeDetails.Fine.Currency.ID,
                        Description = EditModel.EmployeeDetails.Fine.Currency.Description,
                        Description_ka = EditModel.EmployeeDetails.Fine.Currency.Description_ka,
                        Description_ru = EditModel.EmployeeDetails.Fine.Currency.Description_ru
                    },
                    FineType = new FineType()
                    {
                        ID = EditModel.EmployeeDetails.Fine.FineType.ID,
                        Description = EditModel.EmployeeDetails.Fine.FineType.Description
                    },

                },
                Forgiveness = new Forgiveness()
                {
                    ID = EditModel.EmployeeDetails.Forgiveness.ID,
                    Amount = EditModel.EmployeeDetails.Forgiveness.Amount,
                    ForgivenessTypeID = EditModel.EmployeeDetails.Forgiveness.ForgivenessTypeID,
                    ForgivenessType = new ForgivenessType()
                    {
                        ID = EditModel.EmployeeDetails.Forgiveness.ForgivenessType.ID,
                        Description = EditModel.EmployeeDetails.Forgiveness.ForgivenessType.Description
                    }
                },
                Salary = new Salary()
                {
                    ID = EditModel.EmployeeDetails.Salary.ID,
                    Amount = EditModel.EmployeeDetails.Salary.Amount,
                    CurrencyID = EditModel.EmployeeDetails.Salary.CurrencyID,
                    IsHourly = EditModel.EmployeeDetails.Salary.IsHourly,
                    SalaryTypeID = EditModel.EmployeeDetails.Salary.SalaryTypeID,
                    Currency = new Currency()
                    {
                        ID = EditModel.EmployeeDetails.Salary.Currency.ID,
                        Description = EditModel.EmployeeDetails.Salary.Currency.Description,
                        Description_ka = EditModel.EmployeeDetails.Salary.Currency.Description_ka,
                        Description_ru = EditModel.EmployeeDetails.Salary.Currency.Description_ru
                    },
                    SalaryType = new SalaryType()
                    {
                        ID = EditModel.EmployeeDetails.Salary.SalaryType.ID,
                        Description = EditModel.EmployeeDetails.Salary.SalaryType.Description
                    }
                }
                
                
            };
            result.EmployeeHolidays = new List<EmployeeHolidays>()
            {
                new EmployeeHolidays()
                {
                    EmployeeID=EditModel.EmployeeHolidays.FirstOrDefault().EmployeeID,
                     HolidayTypeID=EditModel.EmployeeHolidays.FirstOrDefault().HolidayTypeID,
                      AllWritten=EditModel.EmployeeHolidays.FirstOrDefault().AllWritten,
                       ID=EditModel.EmployeeHolidays.FirstOrDefault().ID,
                        IsActive=EditModel.EmployeeHolidays.FirstOrDefault().IsActive,
                         Left=EditModel.EmployeeHolidays.FirstOrDefault().Left,
                          LeftInYear=EditModel.EmployeeHolidays.FirstOrDefault().LeftInYear,
                           NumInYear=EditModel.EmployeeHolidays.FirstOrDefault().NumInYear,
                            DeactivateDate=EditModel.EmployeeHolidays.FirstOrDefault().DeactivateDate,
                             Used=EditModel.EmployeeHolidays.FirstOrDefault().Used,
                              HolidayType=new HolidayType()
                              {
                                  ID=EditModel.EmployeeHolidays.FirstOrDefault().HolidayType.ID,
                                   Description=EditModel.EmployeeHolidays.FirstOrDefault().HolidayType.Description
                              }
                }
            };
            result.EmployeeMobileNumbers = new List<EmployeeMobileNumbers>()
            {
                new EmployeeMobileNumbers()
                {
                     ID=EditModel.EmployeeMobileNumbers.FirstOrDefault().ID,
                      PhoneNumber=EditModel.EmployeeMobileNumbers.FirstOrDefault().PhoneNumber,
                       EmployeeID=EditModel.EmployeeMobileNumbers.FirstOrDefault().EmployeeID,
                        IsActive=EditModel.EmployeeMobileNumbers.FirstOrDefault().IsActive
                }
            };
            result.Gender = new Gender()
            { ID=EditModel.Gender.ID,
                Description=EditModel.Gender.Description
            };
            result.Schedule = new Schedule()
            {
                ID = EditModel.Schedule.ID,
                EndTime = EditModel.Schedule.EndTime,
                EmployeeID = EditModel.Schedule.EmployeeID,
                DaylyHouresAmount = EditModel.Schedule.DaylyHouresAmount,
                IsActive = EditModel.Schedule.IsActive,
                NotStandartSchedule = EditModel.Schedule.NotStandartSchedule,
                OnWorkingDaysOnly = EditModel.Schedule.OnWorkingDaysOnly,
                OnWorkingHouresOnly = EditModel.Schedule.OnWorkingHouresOnly,
                ScheduleTypeID = EditModel.Schedule.ScheduleTypeID,
                StartTime = EditModel.Schedule.StartTime,
                WeekHouresAmount = EditModel.Schedule.WeekHouresAmount,
                ScheduleDetails = new List<ScheduleDetails>()
                {
                    new ScheduleDetails()
                    {
                        ID=EditModel.Schedule.ScheduleDetails.FirstOrDefault().ID,
                         Date=EditModel.Schedule.ScheduleDetails.FirstOrDefault().Date,
                          EndTime=EditModel.Schedule.ScheduleDetails.FirstOrDefault().EndTime,
                           StartTime=EditModel.Schedule.ScheduleDetails.FirstOrDefault().StartTime,
                            HasPassed=EditModel.Schedule.ScheduleDetails.FirstOrDefault().HasPassed,
                             ScheduleID=EditModel.Schedule.ScheduleDetails.FirstOrDefault().ScheduleID
                    }
                },
                ScheduleType = new ScheduleType()
                {
                    ID = EditModel.Schedule.ScheduleType.ID,
                    Description = EditModel.Schedule.ScheduleType.Description
                }
            };
            _database.Entry(result).State = System.Data.Entity.EntityState.Modified;
            _database.SaveChanges();
            return result;

        }
    }
}
