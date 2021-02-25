﻿using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDeviceLocationInBranchRepository:IBaseRepository<DeviceLocationInBranch>
    {
        IEnumerable<DeviceLocationInBranch> GetDeviceLocationInBranches();
        DeviceLocationInBranch AddDeviceLocationInBranch(DeviceLocationInBranch model);
        DeviceLocationInBranch EditDeviceLocationInBranch(DeviceLocationInBranch model);
    }
}
