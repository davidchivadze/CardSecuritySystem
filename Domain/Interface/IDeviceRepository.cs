using Models.EntityModels;
using Models.LinqJoinDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDeviceRepository:IBaseRepository<Device>
    {
        Device AddDevice(Device device);
        Device EditDevice(Device device);
        bool DeleteDevice(int id);
        IEnumerable<Device> GetDevices();
        IEnumerable<DeviceRegistratedUsersToEmployee> GetDeviceRegistratedUsers();
    }
}
