using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class UserInfro
    {
        public int MachineNumber { get; set; }
        public int EnrollNumber { get; set; }
        public int BackUpNumber { get; set; }
        public int Privelage { get; set; }
        public int Enabled { get; set; }
    }
}