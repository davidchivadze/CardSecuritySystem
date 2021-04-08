using Core.Helper.RepositoryHelperClasses;
using Models;
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
        IEnumerable<Employee> GetFilteredEmployees(EmployeeFilter filterModel);
        Employee AddEmployee(Employee addModel);
        Employee UpdateEmployeeSyncData(int deviceUserID,int userID);
    }
}
