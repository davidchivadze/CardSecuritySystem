using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Employee
{
    public class EditEmployeeHolidayReqRequest
    {
        public int ID { get; set; }
        public int HolidayTypeID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int EmployeeID { get; set; }
    }

    public class EditEmployeeHolidayReqResponse
    {
    }
}
