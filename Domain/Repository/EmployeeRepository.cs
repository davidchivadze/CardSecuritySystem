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
        public EmployeeRepository(Data database):base(database)
        {
        }

        public IEnumerable<Employee> GetActiveEmployees(bool isActive)
        {
            return _database.Employees.Where(e => e.IsActive);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _database.Employees;
        }

        public IEnumerable<Employee> GetEmployeesByBranch(int branchID)
        {
            return _database.Employees.Where(e => e.BranchID == branchID);
        }

        public IEnumerable<Employee> GetEmployeesByDepartment(int departmentID)
        {
            return _database.Employees.Where(e=>e.DepartmentID == departmentID);
        }
    }
}
