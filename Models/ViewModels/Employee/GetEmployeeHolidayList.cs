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
        public int ID { get; set; }
        public string Name { get; set; }
        public string AllWritten { get; set; }
        public string Left { get; set; }
        public string Used { get; set; }
        public string NumInYear { get; set; }
        public string LeftInYear { get; set; }
        public DateTime DeactivateDate { get; set; }
        public bool IsActive { get; set; }

        public int EmployeeID { get; set; }

    }
}
