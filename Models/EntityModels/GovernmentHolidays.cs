using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class GovernmentHolidays
    {
        [Key]
        public int ID { get; set; }
        public DateTime HolidayDate { get; set; }
        public string Description { get; set; }
    }
}
