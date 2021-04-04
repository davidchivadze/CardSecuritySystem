using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class AddEmployeePositionRequest
    {
        public string Description { get; set; }
    }

    public class AddEmployeePositionResponse
    {
    }

    public class GetEmployeePositionItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
