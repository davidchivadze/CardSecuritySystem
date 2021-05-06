using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Employee
{
    public class GetEmployeeFullReportResponse
    {


        public List<GetEmployeeFullReportItem> GetEmployeeFullReportItems { get; set; }
    }
    public class GetEmployeeFullReportItem
    {

        //თანამშრომელი	დეპარტამენტი	სერვის ცენტრი	განყოფილება	სულ დაგვიანება	სულ ადრე გასვლა	სულ ადრე მოსვლა	სულ გვიან გასვლა	სულ ნამუშევარი საათები	ხელფასი	გვიან მოსვლების რაოდენობა 	ჯარიმა სულ	ადრე გასვლები რაოდენობა	სულ იმუშავა გრაფიკში	სულ იმუშავა გრაფიკს გარეთ	დღის გაცდენა					

        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string ServiceCenter { get; set; }
        public int SumLateMinutes { get; set; }
        public int SumLateCheckInCount { get; set; }
        public int SumEarlyMinutes { get; set; }
        public int SumEarlyCheckOut { get; set; }
        public int SumLateCheckOut { get; set; }
        public int SumWorkedHoures { get; set; }
        public int SumEarlyCheckOutCount { get; set; }
        public int SumEarlyCheckInCount { get; set; }
        public int SumWorkedInSchedule { get; set; }
        public int SumWorkedOutOfSchedule { get; set; }
        public int SumMissedDays { get; set; }
        public decimal SalaryAmount { get; set; }
        public decimal FineAmount { get; set; }
        public decimal SalaryAfterFine { get; set; }
        public int IndRegID { get; set; }
        public List<EmployeeWorkingLogItems> EmployeeWorkingLogs { get; set; }
    }
    public class EmployeeWorkingLogItems
    {
    
        public DateTime? ScheduleFromTime { get; set; }
        public DateTime? ScheduleToTime { get; set; }
        public bool IsWorkingDay { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public int? LateCheckInMinutes { get; set; }
        public int? EarlyCheckInMinutes { get; set; }
        public int? EarlyCheckOutMinutes { get; set; }
        public int? LateCheckOutMinutes { get; set; }
        public string WorkStatus { get; set; }

        public int? WorkedMinutess { get; set; }
        public int? FineMinutes { get; set; }
        public int? WorkedInSchedule { get; set; }
        public int? WorkedOutSchedule { get; set; }
        public int? MissedMinutes { get; set; }
    }
}
