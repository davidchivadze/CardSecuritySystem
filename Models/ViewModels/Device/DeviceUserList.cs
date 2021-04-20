using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Device
{
    public class DeviceUserListRequest
    {
        public bool IsRegistrated { get; set; }
    }
    public class DeviceUserListResponse
    {
        public List<DeviceUserListItem> deviceUserListItems { get; set; }
    }
    public class DeviceUserListItem
    {
   
        public int ID { get; set; }
        public int? UserDeviceID { get; set; }
        public int? MachineNumber { get; set; }

        public string Name { get; set; }
        public int? FingerIndex { get; set; }
        public string TmpData { get; set; }
        public int? Privelage { get; set; }
        public string Password { get; set; }
        public bool? Enabled { get; set; }
        public string iFlag { get; set; }
        public bool IsRegistratedSystem { get; set; }
    }
}
