using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class GetDeviceLocationInBranchListResponse
    {
        public List<GetDeviceLocationInBranchListItem> DeviceLocationInBranchList { get; set; }
    }
    public class GetDeviceLocationInBranchListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
