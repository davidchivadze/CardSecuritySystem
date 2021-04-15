using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class RemoteDeviceSyncLogRepository : BaseRepository<RemoteDeviceSyncLog>, IRemoteDeviceSyncLogRepository
    {
        public RemoteDeviceSyncLogRepository(Data database) : base(database)
        {
        }

        public RemoteDeviceSyncLog AddRemoteDeviceSyncLog(RemoteDeviceSyncLog model)
        {
            try
            {

                var log=_database.RemoteDeviceSyncLogs.Add(model);
                _database.SaveChanges();
                return log;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RemoteDeviceSyncLogFinish(int? deviceID,int logID, string ErrorMessage = null)
        {
            var editLog = _database.RemoteDeviceSyncLogs.Where(m => m.ID == logID).FirstOrDefault();
            editLog.EndTime = DateTime.Now;
            editLog.Error = ErrorMessage;
            editLog.IsRuning = false;
            editLog.DeviceID=
            _database.SaveChanges();
            return true;
        }

        public bool SyncIsRunnig()
        {
            var syncRunning = _database.RemoteDeviceSyncLogs.Where(m => m.IsRuning).FirstOrDefault();
            if (syncRunning != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
