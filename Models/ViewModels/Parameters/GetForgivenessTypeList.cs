using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class GetForgivenessTypeListResponse
    {
        public List<GetForgivenessTypeListItem> ForgivenessTypes { get; set; }

    }
    public class GetForgivenessTypeListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }

    }
}
