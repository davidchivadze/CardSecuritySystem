using Business.Interface;
using Core.Helpers;
using Models.ViewModels;
using Models.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //public IResponse<List<EmployeeViewModel>> GetEmployeeList()
        //{
        //    return _employeeService.GetFilteredEmployees();
        //}
        public IResponse<AddEmployeeResposeModel> AddEmployee(AddEmployeeRequestModel request)
        {
            return _employeeService.AddEmployee(request);
        }
        public IResponse<GetEmployeeHolidayListResponse> GetEmployeeHolidayList(GetEmployeeHolidayListRequest model)
        {
            return _employeeService.GetEmployeeHolidayList(model);
        }
        public IResponse<List<AddEmployeeRequestModel>> GetFilteredEmployees()
        {
            return _employeeService.GetFilteredEmployees();
        }
    }
}
