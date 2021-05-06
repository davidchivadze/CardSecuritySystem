using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class GetScheduleGeneratorResponse
    {
       public List<GetScheduleGeneratorItems> ScheduleGeneratorItems { get; set; }
    }
    public class GetScheduleGeneratorItems
    {
        public int? ID { get; set; }
        public string Name { get; set; }

        public int ScheduleTypeID { get; set; }
        public string ScheduleTypeName { get; set; }
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        public TimeSpan MinCheckInTime { get; set; }

        public TimeSpan MaxCheckOutTime { get; set; }
        public double BreakAmount { get; set; }
        public int WeekHouresAmount { get; set; }
        public int DaylyHouresAmount { get; set; }

        public bool OnWorkingDaysOnly { get; set; }
        public bool OnWorkingHouresOnly { get; set; }

    }

    public class AddScheduleGenerator
    {
        public string Name { get; set; }

        public int ScheduleTypeID { get; set; }
        public string ScheduleTypeName { get; set; }
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        public TimeSpan MinCheckInTime { get; set; }

        public TimeSpan MaxCheckOutTime { get; set; }
        public double BreakAmount { get; set; }
        public int WeekHouresAmount { get; set; }
        public int DaylyHouresAmount { get; set; }

        public bool OnWorkingDaysOnly { get; set; }
        public bool OnWorkingHouresOnly { get; set; }

    }
}
