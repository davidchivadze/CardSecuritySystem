using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Device
{
    public class DeleteDeviceRequest
    {
    }
    public class DeleteDeviceItem
    {
        public int ID { get; set; }
        public string IPAddress { get; set; }
        public DateTime LastSyncDate { get; set; }
        public string Branch { get; set; }
        public string LocationInBranch { get; set; }
        public int IsActive { get; set; }
    }
    public class DeleteDeviceResponse
    {

    }
}
