using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class ScheduleDetails
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool HasPassed { get; set; }
        [ForeignKey("Schedule")]
        public bool ScheduleID { get; set; }


        public virtual Schedule Schedule { get; set; }
    }
}
