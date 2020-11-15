﻿using Models;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        IEnumerable<Employee> GetActiveEmployees();
    }
}
