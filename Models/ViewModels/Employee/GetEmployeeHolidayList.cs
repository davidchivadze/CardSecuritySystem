using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Employee
{
    public class GetEmployeeHolidayListRequest
    {
        public int EmployeeID { get; set; }
    }

    public class GetEmployeeHolidayListResponse
    {
        public List<GetEmployeeHolidayListItem> GetEmployeeHolidayList { get; set; }
    }
    public class GetEmployeeHolidayListItem
    {

    }
}
