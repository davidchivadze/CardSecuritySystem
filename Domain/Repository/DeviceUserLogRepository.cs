using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class DeviceUserLogRepository : BaseRepository<DeviceUserLog>, IDeviceUserLogRepository
    {
        public DeviceUserLogRepository(Data database) : base(database)
        {
        }

        public bool AddLogList(List<DeviceUserLog> addList)
        {
            try
            {
                _database.DeviceUserLogs.AddRange(addList);
                _database.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.InnerException);
            }
        }
    }
}
