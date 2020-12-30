using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class GetCitiesListByCountryIDResponse
    {
        public List<GetCitiesListItem> CitiesList { get; set; }
    }

    public class GetCitiesListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
