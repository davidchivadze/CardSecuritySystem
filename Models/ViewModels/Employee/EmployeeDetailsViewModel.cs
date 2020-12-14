using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        public virtual EmployeePositionViewModel EmployeePosition { get; set; }

        public virtual SalaryViewModel Salary { get; set; }

        public virtual BranchViewModel Branch { get; set; }

        public virtual DepartmentsViewModel Department { get; set; }
    }
}
