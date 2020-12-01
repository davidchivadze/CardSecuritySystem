using Domain.Interface;
using Domain.RepositoryHelper;
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

        public IEnumerable<Employee> GetActiveEmployees(bool? isActive, int branchID, int departmentID)
        {
            return _database.Employees.Where(e => isActive.HasValue?e.IsActive==isActive.Value : e.IsActive==e.IsActive);
        }

        public IEnumerable<Employee> GetActiveEmployees(EmployeeFilter filterModel)
        {
            return _database.Employees.Where(e => (filterModel.IsActive.HasValue ? e.IsActive == filterModel.IsActive.Value : e.IsActive == e.IsActive)
                                                && (filterModel.BranchID.HasValue ? e.EmployeeDetails.BranchID == filterModel.BranchID.Value : e.EmployeeDetails.BranchID == e.EmployeeDetails.BranchID)
                                                && (filterModel.DepartmentID.HasValue ? e.EmployeeDetails.BranchID == filterModel.DepartmentID.Value : e.EmployeeDetails.DepartmentID == e.EmployeeDetails.DepartmentID));
        }

        //public IEnumerable<Employee> GetAllEmployees()
        //{
        //    return _database.Employees;
        //}

        //public IEnumerable<Employee> GetEmployeesByBranch(int branchID)
        //{
        //    return _database.Employees.Include();
        //}

        //public IEnumerable<Employee> GetEmployeesByDepartment(int departmentID)
        //{
        //    return _database.Employees.Where(e=>e.DepartmentID == departmentID);
        //}
    }
}
