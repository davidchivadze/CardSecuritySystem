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
        IResponse<EditEmployeeResposeModel> EditEmployee(GetEmployeeForEdit request);
        IResponse<bool> DeleteEmployees(int[] EmployeeIDs);
        IResponse<GetEmployeeForEdit> GetEmployeeForEdit(int EmployeeID);
        IResponse<GetEmployeeHolidayListResponse> GetEmployeeHolidayList(GetEmployeeHolidayListRequest model);
        IResponse<GetEmployeeListResponse> GetEmployeeList();
        IResponse<bool> DeleteEmployee(int employeeID);
        IResponse<GetGovernmentHolidayListResponse> GetGovernmentHolidayList();
        IResponse<AddGovernmentResponse> AddGovernmentHoliday(AddGovernmentRequest model);
        IResponse<EditGovernmentHolidayResponse> EditGovernmentHoliday(EditGovernmentHolidayRequest model);
        IResponse<bool> DeleteGovernmentHoliday(int governmentHolidayID);
        IResponse<GetEmployeeHolidayReqListResponse> GetEmployeeHolidayRequestList(GetEmployeeHolidayReqListRequest model);
        IResponse<AddEmployeeHolidayReqResponse> AddEmployeeHolidayRequest(AddEmployeeHolidayReqRequest model);
        IResponse<EditEmployeeHolidayReqResponse> EditEmployeeHolidayRequest(EditEmployeeHolidayReqRequest model);
        IResponse<bool> DeleteEmployeeHolidayRequest(int holidayID);

    }
}
