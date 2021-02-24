using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDeviceTypeRepository:IBaseRepository<DeviceType>
    {
        IEnumerable<DeviceType> GetDeviceTypes();
    }
}
