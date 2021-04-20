using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Device
{
    public class AddDeviceRequest
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public int NumberDevices { get; set; }
        public string IPAddress { get; set; }
        public int DeviceTypeID { get; set; }
        public int BranchID { get; set; }  
        public int DeviceLocationInBranchID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
    }
    public class AddDeviceResponse
    {
        
    }
}
