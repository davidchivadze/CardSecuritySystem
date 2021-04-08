using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.LinqJoinDatabaseModels
{
    public class DeviceAndDbUsersJoin
    {
        public string FirsName { get; set; }

        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string RecordTime { get; set; }
        public int? UserIDInDevice { get; set; }
        public int MachineNumber { get; set; }
        public int VerifyMode { get; set; }
    }
}
