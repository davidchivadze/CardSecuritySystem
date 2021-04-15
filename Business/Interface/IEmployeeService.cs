using Core.Helpers;
using Models.ViewModels;
using Models.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IEmployeeService
    {
        IResponse<List<GetEmployeeListItem>> GetFilteredEmployees();
        IResponse<AddEmployeeResposeModel> AddEmployee(AddEmployeeRequestModel request);
        IResponse<EditEmployeeResposeModel> EditEmployee(EditEmployeeRequestModel request);
        IResponse<GetEmployeeHolidayListResponse> GetEmployeeHolidayList(GetEmployeeHolidayListRequest model);
        IResponse<GetEmployeeListResponse> GetEmployeeList();
        IResponse<bool> DeleteEmployee(int employeeID);
    }
}
