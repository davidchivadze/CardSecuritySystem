using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class GetCountryListResponse
    {
        public List<GetCountryListItem> CountryList { get; set; }
    }
    public class GetCountryListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
