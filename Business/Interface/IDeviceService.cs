﻿using Core.Helpers;
using Models.ViewModels.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IDeviceService
    {
        IResponse<DateTime> GetDeviceDateTime();
        IResponse<bool> AddDevice(AddDeviceRequest model);
        Task<IResponse<bool>> SyncUserLog();
        Task<IResponse<bool>> UpdateUserListFromDevice();
    }
}
