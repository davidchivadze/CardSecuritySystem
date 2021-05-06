using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Employee
{
    public class GetEmployeeModReportResponse
    {
        public List<GetEmployeeModReportItems> WorkingLog { get; set; }
        public string EmployeeFullname { get; set; }
        public string PersonalNumber { get; set; }
        public string Position { get; set; }
        public decimal SumFirstHalf { get; set; }
        public decimal SumSecondHalf { get; set; }
        public decimal SumHouresInMonth { get; set; }
        public int SumDaysInMonth { get; set; }
        public decimal SumNightHoures { get; set; }
        public int SumHolidaysWithoutCompensate { get; set; }
        public int SumGovermentHolidays { get; set; }
        public decimal WorkedHouresInGovermentHolidays { get; set; }
        public int SumHolidayes { get; set; }
        public int OverTime { get; set; }
        public int NightHoures { get; set; }
    }
    public class GetEmployeeModReportItems
    {
        public DateTime Date { get; set; }
        public decimal WorkedTime { get; set; }
        public string WorkedTimeHoures { get; set; }
    }
}
