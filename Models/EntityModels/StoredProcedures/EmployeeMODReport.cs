using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels.StoredProcedures
{
    public class EmployeeMODReport:BaseModel
    {
        public string FullName { get; set; }
        public int MinutesSum { get; set; }
        public int IndRegID { get; set; }
        public DateTime DateRecord { get; set; }
        public string Status { get; set; }
        public int EmployeeID { get; set; }
        public string PersonalNumber { get; set; }
        public string Position { get; set; }
    }
}
