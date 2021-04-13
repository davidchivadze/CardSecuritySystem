using Domain.Interface;
using Models;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helper.RepositoryHelperClasses;

namespace Domain.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Data database):base(database){}

        public IEnumerable<Employee> GetFilteredEmployees(EmployeeFilter filterModel)
        {
            return _database.Employees.Include("EmployeeDetails").Include("EmployeeDetails.Branch").Where(e => (filterModel.IsActive.HasValue ? e.IsActive == filterModel.IsActive.Value : e.IsActive == e.IsActive)
                                               && (filterModel.BranchID.HasValue ? e.EmployeeDetails.BranchID == filterModel.BranchID.Value : e.EmployeeDetails.BranchID == e.EmployeeDetails.BranchID)
                                               && (filterModel.DepartmentID.HasValue ? e.EmployeeDetails.BranchID == filterModel.DepartmentID.Value : e.EmployeeDetails.DepartmentID == e.EmployeeDetails.DepartmentID)).Where(m=>m.IsActive);
        }
        public Employee AddEmployee(Employee addModel)
        {
            var result= _database.Employees.Add(addModel);
            _database.SaveChanges();
            return result;
        }

        public Employee UpdateEmployeeSyncData(int deviceUserID,int userID)
        {
            var editUser = _database.Employees.Where(m => m.ID == userID).FirstOrDefault();
            editUser.UserIDInDevice = deviceUserID;
            _database.SaveChanges();
            return editUser;
        }

        public bool DeleteEmployee(int employeeID)
        {
            var result = _database.Employees.Where(m => m.ID == employeeID).FirstOrDefault();
            result.IsActive = false;
            _database.SaveChanges();
            return true;
        }
    }
}
