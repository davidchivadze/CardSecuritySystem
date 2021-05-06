﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Employee
{
    public class GetEmployeeForEdit
    {
        public int ID { get; set; }
        public string AvatarImage { get; set; }
        public int? EmployeeDetailsID { get; set; }
        public string FirsName { get; set; }
        
        public string FirsName_ka { get; set; }

        public string FirsName_ru { get; set; }

        public string LastName { get; set; }

        public string LastName_ka { get; set; }

        public string LastName_ru { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Address_ka { get; set; }

        public string Address_ru { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; } = true;
        public int? EmployeePositionID { get; set; }
        public string DeviceCardID { get; set; }

        public int SalaryID { get; set; }
        public int? UserIDInDevice { get; set; }

        public int? BranchID { get; set; }

        public int? DepartmentID { get; set; }
        public int? GenderID { get; set; }
        public string PersonalNumber { get; set; }

        public string[] MobileNumbers { get; set; }
        public Forgiveness Forgiveness { get; set; }
        public Fine Fine { get; set; }
        public SalaryData Salary { get; set; }
        public ScheduleData Schedule { get; set; }
        public List<EmployeeHolidays> EmployeeHolidays { get; set; }
    }
}
