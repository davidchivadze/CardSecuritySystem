using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class RemoteDeviceSyncLog:BaseModel
    {

        [Key]
        public int ID { get; set; }

        public int? DeviceID { get; set; }
        public bool IsRuning { get; set; }
        public string Error { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
 
    }
}
