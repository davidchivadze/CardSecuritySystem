using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Employee
{
    public class GetGovernmentHolidayListResponse
    {
        public List<GetGovernmentHolidayListItem> GovernmentHolidayList { get; set; }
    }
    public class GetGovernmentHolidayListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime HolidayDate { get; set; }
    }
}
