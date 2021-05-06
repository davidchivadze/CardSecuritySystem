using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IEmployeeHolidayRequestRepository : IBaseRepository<EmployeeHolidayRequest>
    {
        IEnumerable<EmployeeHolidayRequest> GetHolidayRequestByEmployee(int? empID);
        EmployeeHolidayRequest AddHolidayRequest(EmployeeHolidayRequest addHoliday);
        EmployeeHolidayRequest UpdateHolidayRequest(EmployeeHolidayRequest Holiday);
        bool Delete(int holidayID);
    }
}
