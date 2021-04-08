using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
   public class DeviceLocationInBranch:BaseModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        [ForeignKey("Branches")]
        public int BranchID { get; set; }
        public Branch Branches { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
