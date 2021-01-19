using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class GetCurrencyTypeListResponse
    {
        public List<GetCurrencyTypeListItem> CurrencyTypes { get; set; }

    }
    public class GetCurrencyTypeListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }

    }
}
