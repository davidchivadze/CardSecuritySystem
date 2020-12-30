using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class GetDepartmentsListResponse
    {
        public List<GetDepartmentsListItem> DepartmentsList { get; set; }
    }
    public class GetDepartmentsListItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
