using Core.Helpers;
using Domain.Interface;
using Models;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class EmployeeHolidayRepository:BaseRepository<EmployeeHolidays>,IEmployeeHolidayRepository
    {
        public EmployeeHolidayRepository(Data database) : base(database)
        {

        }

        public EmployeeHolidays AddHoliday(EmployeeHolidays addModel)
        {
            var result = _database.EmployeeHolidays.Add(addModel);
            _database.SaveChanges();
            return result;
        }

        public void Delete(EmployeeHolidays holiday)
        {
            _database.EmployeeHolidays.Remove(holiday);
            _database.SaveChanges();
        }

        public IEnumerable<EmployeeHolidays> GetHolidayByEmployee(int empID)
        {
            var result=_database.EmployeeHolidays.Where(s => s.EmployeeID==empID);
            return result;
        }

        public void UpdateHoliday(EmployeeHolidays holiday)
        {
            var result = _database.EmployeeHolidays.FirstOrDefault(h => h.ID == holiday.ID);
            if (result != null)
            {
                result.ID = holiday.ID;
                result.IsActive = holiday.IsActive;
                result.Left = holiday.Left;
                result.LeftInYear = holiday.LeftInYear;
                result.Name = holiday.Name;
                result.NumInYear = holiday.NumInYear;
                result.Used = holiday.Used;
                result.AllWritten = holiday.AllWritten;
                result.DeactivateDate = holiday.DeactivateDate;
                //result.Employee = holiday.Employee;
                result.EmployeeID = result.EmployeeID;
                _database.Entry(result).State = System.Data.Entity.EntityState.Modified;
                _database.SaveChanges();
            }
        }
    }
}
