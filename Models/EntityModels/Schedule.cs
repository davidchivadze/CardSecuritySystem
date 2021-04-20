using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class Schedule
    {
        //1.სტანდარტული StartTime/EndTime და აუცილებელი მოსანიშნი ველია OnWorkingDaysOnly(მხოლოდ სამუშაო დღეებში)

        //2.სტანდარტული StartTime/EndTime და აუცილებელი მოსანიშნი ველია OnWorkingDaysOnly(მხოლოდ სამუშაო დღეებში)
        //3.DaylyHouresAmount da WeekHouresAmount თუ მაქვს დრო მიწერილი მაშინ დღეში უნდა იმუშაოს ან კვირაში ეს დრო.
        //4. თუ მონიშნულია OnWorkingHouresOnly და DaylyHouresAmount/WeekHouresAmount მაშინ სამუშაო საათებში მინიმუმი დრო ოფისში
        //5.
        [Key]
        public int ID { get; set; }
        [ForeignKey("ScheduleType")]
        public int ScheduleTypeID { get; set; }
        public int EmployeeID { get; set; }
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        public TimeSpan MinCheckInTime { get; set; }

        public TimeSpan MaxCheckOutTime { get; set; }
        public double BreakAmount { get; set; }
        public int WeekHouresAmount { get; set; }
        public int DaylyHouresAmount { get; set; }

        public bool OnWorkingDaysOnly { get; set; }
        public bool OnWorkingHouresOnly { get; set; }
        public bool NotStandartSchedule { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Employee> Employee { get; set; }
        public  ScheduleType ScheduleType { get; set; }
        public ICollection<ScheduleDetails> ScheduleDetails { get; set; }


    }
}
