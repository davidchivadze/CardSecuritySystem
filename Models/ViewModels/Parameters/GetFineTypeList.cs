using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class GetFineTypeListResponse
    {
        public List<GetFineTypeListItem> FineTypes { get; set; }
    }
    public class GetFineTypeListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }

    }
}
