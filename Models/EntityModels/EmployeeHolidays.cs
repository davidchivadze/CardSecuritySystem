﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class EmployeeHolidays:BaseModel
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("HolidayType")]
        public int HolidayTypeID { get; set; }
        public int AllWritten { get; set; }
        public int Left { get; set; }
        public int Used { get; set; }
        public int NumInYear { get; set; }
        public int LeftInYear { get; set; }
        public DateTime? DeactivateDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual HolidayType HolidayType { get; set; }
    }
}
