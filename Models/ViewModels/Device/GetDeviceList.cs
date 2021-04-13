﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Device
{
    public class GetDeviceListRequest
    {
        public int ID { get; set; }
        public string IPAddress { get; set; }
        public DateTime LastSyncDate { get; set; }
        public string Branch { get; set; }
        public string LocationInBranch { get; set; }
        public int State { get; set; }
    }

    public class GetDeviceListResponse
    {

        public List<GetDeviceListRequest> DeviceList { get; set; }
    }
}
