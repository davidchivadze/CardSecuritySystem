﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Parameters
{
    public class AddDepartmentRequest
    {
        public int? ParentDepartmentID { get; set; }
        public string Description { get; set; }
    }

    public class AddDepartmentResponse
    {
    }
}
