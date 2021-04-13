using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Device
{
    public class GetDeviceUserLogResponse
    {
        public List<GetDeviceUserLogItem> DeviceUserLogList { get; set; }
    }
    public class GetDeviceUserLogItem
    {
        public string FirsName { get; set; }

        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime RecordTime { get; set; }
        public int? UserIDInDevice { get; set; }
        public int MachineNumber { get; set; }
        public int VerifyMode { get; set; }
        public bool IsActive { get; set; }
    }
}
