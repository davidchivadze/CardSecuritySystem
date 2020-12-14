using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class ScheduleType
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public  virtual IEnumerable<Schedule> Schedules { get; set; }
    }
}
