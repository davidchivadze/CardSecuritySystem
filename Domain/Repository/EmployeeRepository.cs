using Domain.Interface;
using Models;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public IEnumerable<Employee> GetActiveEmployee()
        {
            var result = Database.Employees.ToList();
            return Database.Employees;
        }
    }
}
