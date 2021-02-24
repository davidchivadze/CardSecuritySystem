using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class DeviceLocationInBranchRepository : BaseRepository<DeviceLocationInBranch>, IDeviceLocationInBranchRepository
    {
        public DeviceLocationInBranchRepository(Data database) : base(database)
        {
        }

        public IEnumerable<DeviceLocationInBranch> GetDeviceLocationInBranches()
        {
            return _database.DeviceLocationInBranches;
        }
    }
}
