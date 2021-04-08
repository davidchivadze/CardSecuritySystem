using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Employee
{

    public class GetEmployeeListResponse
    {
        public List<GetEmployeeListItem> GetEmployeeList { get; set; }
    }
    public class GetEmployeeListItem
    {
        public int ID { get; set; }
        public string FirsName { get; set; }

        public string FirsName_ka { get; set; }

        public string FirsName_ru { get; set; }

        public string LastName { get; set; }

        public string LastName_ka { get; set; }

        public string LastName_ru { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Address_ka { get; set; }

        public string Address_ru { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; } = true;
        public string EmployeePosition { get; set; }
        public string DeviceCardID { get; set; }
        public int? UserIDInDevice { get; set; }

        public string BranchName { get; set; }

        public string DepartmentName { get; set; }
        public string Gender { get; set; }
        public string PersonalNumber { get; set; }

        public string[] MobileNumbers { get; set; }
        public int Forgiveness { get; set; }
        public Decimal Fine { get; set; }
        public Decimal Salary { get; set; }
        //public ScheduleData Schedule { get; set; }
        //public List<EmployeeHolidays> EmployeeHolidays { get; set; }
    }
}
