using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class AddDeviceLocationInBranchRequest
    {
        public string Description { get; set; }
        public int BranchID { get; set; }
    }

    public class AddDeviceLocationInBranchResponse
    {
    }
}
