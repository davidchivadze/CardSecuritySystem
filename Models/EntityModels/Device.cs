using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class Device
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumberDevices { get; set; }
        public string IPAddress { get; set; }
        public DateTime LastSyncDate { get; set; }
        [ForeignKey("DeviceType")]
        public int DeviceTypeID { get; set; }
        [ForeignKey("Branch")]
        public int BranchID { get; set; }
        [ForeignKey("DeviceLocationInBranch")]
        public int DeviceLocationInBranchID { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public bool IsActive { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual DeviceType DeviceType { get; set; }
        public virtual DeviceLocationInBranch DeviceLocationInBranch { get; set; }
    }
}
