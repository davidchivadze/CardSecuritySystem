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
        public int HolidayTypeID { get; set; }
        public int AllWritten { get; set; }
        public int Left { get; set; }
        public int Used { get; set; }
        public int NumInYear { get; set; }
        public int LeftInYear { get; set; }
        public DateTime? DeactivateDate { get; set; }
        public bool IsActive { get; set; }

        public int EmployeeID { get; set; }

    }
}
