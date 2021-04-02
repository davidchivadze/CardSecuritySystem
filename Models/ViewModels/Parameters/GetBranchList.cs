using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class GetBranchListResponse
    {
        public List<GetBranchListItem> BranchList { get; set; }
    }

    public class GetBranchListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
