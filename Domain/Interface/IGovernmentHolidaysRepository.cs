using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IGovernmentHolidaysRepository:IBaseRepository<GovernmentHolidays>
    {
        IEnumerable<GovernmentHolidays> GetGovernmentHolidays();
        GovernmentHolidays AddGHoliday(GovernmentHolidays addGHoliday);
        GovernmentHolidays UpdateGHoliday(GovernmentHolidays gHoliday);
        bool Delete(int gHolidayID);
    }
}
