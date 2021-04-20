using Business.Interface;
using Core.Helpers;
using Models.ViewModels.Parameters;
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

   
    public class ParametersController : ApiController
    {
        private IParametersService _parametersService;
        public ParametersController(IParametersService parametersService)
        {
            this._parametersService = parametersService;
        }
        //[JwtAuthentication]
         
        public IResponse<GetGenderListResponse> GetGenderList()
        {
            return _parametersService.GetGenderList();
        }
         
        public IResponse<GetDepartmentsListResponse> GetDepartmentsList()
        {
            return _parametersService.GetDepartmentsList();
        }
         
        public IResponse<AddDepartmentResponse> AddDepartment(AddDepartmentRequest model)
        {
            return _parametersService.AddDepartment(model);
        }
         
        public IResponse<EditDeparmentResponse> EditDepartment(EditDepartmentRequest model)
        {
            return _parametersService.EditDepartment(model);
        }
         
        public IResponse<GetBranchListResponse> GetBranchList()
        {
            return _parametersService.GetBranchList();
        }
         
        public IResponse<GetBranchListItem> GetBranchForEdit(int id)
        {
            return _parametersService.GetBranchForEdit(id);
        }
         
        [HttpGet]
        public IResponse<bool> DeleteBranch(int branchID)
        {
            return _parametersService.DeleteBranch(branchID);
        }
         
        [HttpGet]
        public IResponse<bool> DeleteDepartment(int departmentID)
        {
            return _parametersService.DeleteDepartment(departmentID);
        }
         
        [HttpGet]
        public IResponse<bool> DeleteDevice(int DeviceID)
        {
            return _parametersService.DeleteDevice(DeviceID);
        }
         
        [HttpGet]
        public IResponse<bool> DeleteEmployeePosition(int employeePositionID)
        {
            return _parametersService.DeleteEmployeePosition(employeePositionID);
        }
        //public IResponse<GetEmployeePositionItem> GetEmployeePositionForEdit(int id)
        //{
        //    return _parametersService.GetEmployeePositionForEdit(id);
        //}
         
        public IResponse<AddBranchResponse> AddBranch(AddBranchRequest model)
        {
            return _parametersService.AddBranch(model);
        }
         
        public IResponse<EditBranchResponse> EditBranch(EditBranchRequest model)
        {
            return _parametersService.EditBranch(model);
        }
         
        public IResponse<GetEmployeePositionsResponse> GetEmployeePositionsList()
        {
            return _parametersService.GetEmployeePositionsList();
        }
         
        public IResponse<AddEmployeePositionResponse> AddEmployeePositionType(AddEmployeePositionRequest model)
        {
            return _parametersService.AddEmployeePosition(model);
        }
         
        public IResponse<EditEmployeePositionResponse> EditEmployeePosition(EditEmployeePositionRequest model)
        {
            return _parametersService.EditEmployeePosition(model);
        }
         
        public IResponse<GetSalaryTypeListResponse> GetSalaryTypesList()
        {
            return _parametersService.GetSalaryTypeList();
        }
         
        public IResponse<AddSalaryTypeResponse> AddSalaryType(AddSalaryTypeRequest model)
        {
            return _parametersService.AddSalaryType(model);
        }
         

        public IResponse<EditSalaryTypeResponse> EditSalaryType(EditSalaryTypeRequest model)
        {
            return _parametersService.EditSalaryType(model);
        }
         
        public IResponse<GetFineTypeListResponse> GetFineTypesLIst()
        {
            return _parametersService.GetFineTypeList();
        }
         
        public IResponse<AddFineTypeResponse> AddFineType(AddFineTypeRequest model)
        {
            return _parametersService.AddFineType(model);
        }
         
        public IResponse<EditFineTypeResponse> EditFineType(EditFineTypeRequest model)
        {
            return _parametersService.EditFineType(model);
        }
         
        public IResponse<GetForgivenessTypeListResponse> GetForgivenessTypesLIst()
        {
            return _parametersService.GetForgivenessTypeList();
        }
         
        public IResponse<GetCountryListResponse> GetCountryList()
        {
            return _parametersService.GetCountryList();
        }
         
        public IResponse<GetCitiesListByCountryIDResponse> GetCitiesListByCountryID(int? countryID)
        {
            return _parametersService.GetCitiesListByCountryID(countryID);
        }
         
        public IResponse<GetDeviceTypeListResponse> GetDeviceTypeList()
        {
            return _parametersService.GetDeviceTypeList();
        }
         
        public IResponse<GetDeviceLocationInBranchListResponse> GetDeviceLocationInBranchList()
        {
            return _parametersService.GetDeviceLocationInBranchListResponse();
        }
         
        public IResponse<AddDeviceLocationInBranchResponse> AddDeviceLocationInBranch(AddDeviceLocationInBranchRequest model)
        {
            return _parametersService.AddDeviceLocationInBranch(model);
        }
         
        public IResponse<EditDeviceLocationInBranchResponse> EditDeviceLocationInBranch(EditDeviceLocationInBranchRequest model)
        {
            return _parametersService.EditDeviceLocationInBranch(model);
        }
         
        public IResponse<AddForgivenessTypeResponse> AddForgivenessType(AddForgivenessTypeRequest model)
        {
            return _parametersService.AddForgivenessType(model);
        }
         
        public IResponse<EditForgivenessTypeResponse> EditForgivenessType(EditForgivenessTypeRequest model)
        {
            return _parametersService.EditForgivenessType(model);
        }
         
        public IResponse<GetHolidayTypesListResponse> GetHolidayTypeList()
        {
            return _parametersService.GetHolidayTypeList();
        }
    }
}
