using Core.Helpers;
using Models;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IEmployeeHolidayRepository:IBaseRepository<EmployeeHolidays>
    {
        IEnumerable<EmployeeHolidays> GetHolidayByEmployee(int empID);
        EmployeeHolidays AddHoliday(EmployeeHolidays addHoliday);
        void UpdateHoliday(EmployeeHolidays Holiday);
        void Delete(EmployeeHolidays holiday);
    }
}
