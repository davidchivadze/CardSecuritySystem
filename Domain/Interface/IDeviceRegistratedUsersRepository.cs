using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDeviceRegistratedUsersRepository:IBaseRepository<DeviceRegistratedUsers>
    {
        bool AddDeviceRegistratedUsersList(List<DeviceRegistratedUsers> userList);
    }
}
