using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class EmployeeWorkingLog:BaseModel
    {
        [Key]
        public int ID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int IndRegID { get; set; }
        public int Minutes { get; set; }
        [ForeignKey("EmployeeWorkingLogTimeType")]
        public int EmployeeWorkingLogTimeTypeID { get; set; }
        public virtual EmployeeWorkingLogTimeType EmployeeWorkingLogTimeType { get; set; }

    }
}
