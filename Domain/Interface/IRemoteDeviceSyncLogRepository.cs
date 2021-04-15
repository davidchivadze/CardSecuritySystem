using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IRemoteDeviceSyncLogRepository:IBaseRepository<RemoteDeviceSyncLog>
    {
        RemoteDeviceSyncLog AddRemoteDeviceSyncLog(RemoteDeviceSyncLog model);
        bool RemoteDeviceSyncLogFinish(int? deviceID,int logID, string ErrorMessage = null);
        bool SyncIsRunnig();
    }
}
