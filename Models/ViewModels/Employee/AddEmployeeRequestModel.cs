using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class AddEmployeeRequestModel
    {
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
        public int EmployeePositionID { get; set; }

        public int  SalaryID { get; set; }

        public int BranchID { get; set; }

        public int DepartmentID { get; set; }
        public int GenderID { get; set; }

        public string[] MobileNumbers { get; set; }
        public Forgiveness Forgiveness { get; set; }
        public Fine Fine { get; set; }
        public SalaryData Salary { get; set; }
        public ScheduleData Schedule { get; set; }
        public List<EmployeeHolidays> EmployeeHolidays { get; set; }
    }
    public class Forgiveness
    {
        public int ForgivenessTypeID { get; set; }
        public int Amount { get; set; }
        
    }
    public class EmployeeHolidays
    {
        public int HolidayTypeID { get; set; }
        public int AllWritten { get; set; }
        public int Left { get; set; }
        public int Used { get; set; }
        public int NumInYear { get; set; }
        public int LeftInYear { get; set; }
        public DateTime DeactivateDate { get; set; }
        public bool IsActive { get; set; }
    }
    public class Fine
    {
        public int FineTypeID { get; set; }
        public Decimal Amount { get; set; }
        public int CurrencyID { get; set; }
    }
    public class SalaryData
    {
        public decimal Amount { get; set; }
        public int CurrencyID { get; set; }
        public bool IsHourly { get; set; }
        public int SalaryTypeID { get; set; }
    }
    public class ScheduleData
    {
        public int ScheduleTypeID { get; set; }
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        public int WeekHouresAmount { get; set; }
        public int DaylyHouresAmount { get; set; }

        public bool OnWorkingDaysOnly { get; set; }
        public bool OnWorkingHouresOnly { get; set; }
        public bool NotStandartSchedule { get; set; }
        public byte[] ScheduleFileData { get; set; }
        public string FileFormat { get; set; }
    }
    public class AddEmployeeResposeModel
    {

    }
}
