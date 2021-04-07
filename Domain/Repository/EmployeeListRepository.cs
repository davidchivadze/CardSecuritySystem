using Domain.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class EmployeeListRepository : BaseRepository<Employee>, IEmployeeListRepository
    {
        public EmployeeListRepository(Data database) : base(database)
        {
            
        }

        public IEnumerable<Employee> GetEmployeeList()
        {

            return _database.Employees;
        }
    }
}
