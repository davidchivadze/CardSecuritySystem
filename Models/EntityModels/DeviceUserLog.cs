using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class DeviceUserLog:BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int MachineNumber { get; set; }
        public int IndRegID { get; set; }
        public int dwVerifyMode { get; set; }
        public int dwInOutMode { get; set; }
        public string DateTimeRecord { get; set; }
    }
}
