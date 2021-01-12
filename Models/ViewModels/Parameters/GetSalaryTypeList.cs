using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
   public class GetSalaryTypeListResponse
    {
        public List<GetSalaryTypeListItem> SalaryTypes { get; set; }
    }
    public class GetSalaryTypeListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
