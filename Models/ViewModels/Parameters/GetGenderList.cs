using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class GetGenderListResponse
    {
        public List<GetGenderListItem> GenderList { get; set; }
    }
    public class GetGenderListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
