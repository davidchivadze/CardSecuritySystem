﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper.RepositoryHelperClasses
{
    public class EmployeeFilter
    {
        public int? DepartmentID { get; set; }
        public int? BranchID { get; set; }
        public bool? IsActive { get; set; }
    }
}
