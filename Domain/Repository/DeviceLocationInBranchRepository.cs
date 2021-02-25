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

        public DeviceLocationInBranch AddDeviceLocationInBranch(DeviceLocationInBranch model)
        {
            var result = _database.DeviceLocationInBranches.Add(model);
            _database.SaveChanges();
            return result;
        }

        public DeviceLocationInBranch EditDeviceLocationInBranch(DeviceLocationInBranch model)
        {
            var result = _database.DeviceLocationInBranches.Where(m => m.ID == model.ID).FirstOrDefault();
            result.Description = model.Description;
            _database.SaveChanges();
            return result;
        }

        public IEnumerable<DeviceLocationInBranch> GetDeviceLocationInBranches()
        {
            return _database.DeviceLocationInBranches;
        }
    }
}
