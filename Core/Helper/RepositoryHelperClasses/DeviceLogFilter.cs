using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper.RepositoryHelperClasses
{
    public class DeviceLogFilter
    {
        public int? MachineNumber { get; set; }
        public int? IndRegID { get; set; }
        public int? dwVerifyMode { get; set; }
        public int? dwInOutMode { get; set; }
        public string DateTimeRecord { get; set; }
    }
}
