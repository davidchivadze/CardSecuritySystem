using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
   public class GetHolidayTypesListResponse
    {
        public List<GetHolidayTypeListItem> HolidayTypes { get; set; }
    }
    public class GetHolidayTypeListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
