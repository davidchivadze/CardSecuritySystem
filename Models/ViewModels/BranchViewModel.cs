using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class BranchViewModel
    {
        public int CityID { get; set; }
        public int CountryID { get; set; }
        public string Address { get; set; }
        public string BranchName { get; set; }
        public List<Device> Devices { get; set; }
    }

    public class BranchResponseModel { }
}
