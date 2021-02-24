using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
   public class DeviceLocationInBranch:BaseModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
