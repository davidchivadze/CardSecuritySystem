﻿using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDeviceRepository:IBaseRepository<Device>
    {
        Device AddDevice(Device device);
        IEnumerable<Device> GetDevices();
    }
}
