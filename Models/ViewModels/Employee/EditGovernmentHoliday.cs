using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Employee
{
    public class EditGovernmentHolidayRequest
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime HolidayDate { get; set; }

    }

    public class EditGovernmentHolidayResponse
    {
    }
}
