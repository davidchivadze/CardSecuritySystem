using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class DeviceType:BaseModel
    {
        public int ID { get; set;}
        public string Description { get; set; }
        public IEnumerable<Device> Devices { get; set; }
    }
}
