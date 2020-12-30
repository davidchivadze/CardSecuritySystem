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
    }
}
