using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class ScheduleGenerator : BaseModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("ScheduleType")]

        public int ScheduleTypeID { get; set; }
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        public TimeSpan MinCheckInTime { get; set; }

        public TimeSpan MaxCheckOutTime { get; set; }
        public double BreakAmount { get; set; }
        public int WeekHouresAmount { get; set; }
        public int DaylyHouresAmount { get; set; }

        public bool OnWorkingDaysOnly { get; set; }
        public bool OnWorkingHouresOnly { get; set; }

        public bool IsActive { get; set; } = true;

        public ScheduleType ScheduleType {get;set;}
    }
}
