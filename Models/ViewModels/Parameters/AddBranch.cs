using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class AddBranchRequest
    {
        public string BranchName;
        public int CityID;
        public int CountryID;
        public string Address;
    }

    public class AddBranchResponse
    {
    }
}
