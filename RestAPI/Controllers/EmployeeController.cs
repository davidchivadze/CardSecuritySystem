using Business.Interface;
using Core.Helpers;
using Models.ViewModels;
using Models.ViewModels.Employee;
using RestAPI.Authentification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

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
         
        public IResponse<EditEmployeeResposeModel> EditEmployee(GetEmployeeForEdit request)
        {
            return _employeeService.EditEmployee(request);
        }
         
        public IResponse<bool> DeleteEmployees(int[] EmployeeIDs)
        {
            return _employeeService.DeleteEmployees(EmployeeIDs);
        }
         
        public IResponse<GetEmployeeForEdit> GetEmployeeForEdit(int EmployeeID)
        {
            return _employeeService.GetEmployeeForEdit(EmployeeID);
        }
         
        [HttpGet]
        public IResponse<bool> DeleteEmployee(int employeeID)
        {
            return _employeeService.DeleteEmployee(employeeID);
        }
         
        public IResponse<GetEmployeeHolidayListResponse> GetEmployeeHolidayList(GetEmployeeHolidayListRequest model)
        {
            return _employeeService.GetEmployeeHolidayList(model);
        }
         
        public IResponse<GetEmployeeListResponse> GetEmployeeList()
        {
            return _employeeService.GetEmployeeList();
        }
        //public IResponse<List<AddEmployeeRequestModel>> GetFilteredEmployees()
        //{
        //    return _employeeService.GetFilteredEmployees();
        //}
    }
}
