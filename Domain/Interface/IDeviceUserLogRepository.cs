﻿using Models.EntityModels;
using Models.LinqJoinDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDeviceUserLogRepository:IBaseRepository<DeviceUserLog>
    {
        bool AddLogList(List<DeviceUserLog> addList);
        List<DeviceAndDbUsersJoin> GetDeviceUserLogs();
    }
}
