using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class DeviceTypeRepository : BaseRepository<DeviceType>, IDeviceTypeRepository
    {
        public DeviceTypeRepository(Data database) : base(database)
        {
        }

        public IEnumerable<DeviceType> GetDeviceTypes()
        {
            return _database.DeviceTypes;
        }
    }
}
