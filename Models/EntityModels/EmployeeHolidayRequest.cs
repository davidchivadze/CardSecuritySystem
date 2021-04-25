using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class EmployeeHolidayRequest
    {
        [Key]
        public int ID { get; set; }
        public DateTime RegistartionDate { get; set; }
        [ForeignKey("HolidayType")]
        public int HolidayTypeID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int AmountWorkDays { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; } 
        public virtual HolidayType HolidayType { get; set; }
    }
}
