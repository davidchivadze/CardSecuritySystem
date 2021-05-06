using Core.Helper.RepositoryHelperClasses;
using Models;
using Models.EntityModels;
using Models.EntityModels.StoredProcedures;
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
        Employee GetEmployeeForEdit(int EmployeeID);
        Employee GetEmployeeSchedule(int EmployeeID);

        Employee AddEmployee(Employee addModel);
        Employee EditEmployee(Employee EditModel);
        bool DeleteEmployee(int employeeID);
        Employee UpdateEmployeeSyncData(int deviceUserID,int userID);
        ICollection<EmployeeMODReport> GetEmployeeMODReport(DateTime DateFrom, DateTime DateTo, int? EmployeeID);
        ICollection<EmploeeFullReport> GetEmployeeFullReport(DateTime DateFrom, DateTime DateTo, int? EmployeeID);
        bool GenerateModReportData(DateTime DateFrom, DateTime DateTo);

    }
}
