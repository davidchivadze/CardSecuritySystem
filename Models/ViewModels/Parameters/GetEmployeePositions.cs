using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
   public class GetEmployeePositionsResponse
    {
        public List<GetEmployeePositionsListItem> getEmployeePositionsList { get; set; }
    }
    public class GetEmployeePositionsListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
