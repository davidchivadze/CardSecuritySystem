using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Employee
{
    public class AddGovernmentRequest
    {
        public string Description;
        public DateTime HolidayDate { get; set; }
    }

    public class AddGovernmentResponse
    {
    }
}
