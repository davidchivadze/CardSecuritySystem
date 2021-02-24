using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(Data database) : base(database)
        {
        }

        public Device AddDevice(Device device)
        {
            try
            {
                var result = _database.Devices.Add(device);
                _database.SaveChanges();
                return result;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message + "; Inner Exception" + ex.InnerException);
            }
        }
    }
}
