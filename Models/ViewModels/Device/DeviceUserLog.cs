using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DeviceResponseModels
{
   public class DeviceUserLog
    {

            public int MachineNumber { get; set; }
            public int IndRegID { get; set; }
            public int dwVerifyMode { get; set; }
            public int dwInOutMode { get; set; }
            public string DateTimeRecord { get; set; }


            public DateTime DateOnlyRecord
            {
                get { return DateTime.Parse(DateTime.Parse(DateTimeRecord).ToString("yyyy-MM-dd")); }
            }
            public DateTime TimeOnlyRecord
            {
                get { return DateTime.Parse(DateTime.Parse(DateTimeRecord).ToString("hh:mm:ss tt")); }
            }

        
    }
}
