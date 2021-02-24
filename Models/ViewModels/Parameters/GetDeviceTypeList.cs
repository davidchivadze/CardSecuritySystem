﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class GetDeviceTypeListResponse
    {
        public List<GetDeviceTypeListItem> DeviceTypeList { get; set; }
    }
    public class GetDeviceTypeListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
