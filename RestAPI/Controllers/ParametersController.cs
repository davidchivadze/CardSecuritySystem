using Business.Interface;
using Core.Helpers;
using Models.ViewModels.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class ParametersController : ApiController
    {
        private IParametersService _parametersService;
        public ParametersController(IParametersService parametersService)
        {
            this._parametersService = parametersService;
        }
        public IResponse<GetGenderListResponse> GetGenderList()
        {
            return _parametersService.GetGenderList();
        }
        public IResponse<GetDepartmentsListResponse> GetDepartmentsList()
        {
            return _parametersService.GetDepartmentsList();
        }
        public IResponse<GetBranchListResponse> GetBranchList()
        {
            return _parametersService.GetBranchList();
        }
        public IResponse<GetEmployeePositionsResponse> GetEmployeePositionsList()
        {
            return _parametersService.GetEmployeePositionsList();
        }
        public IResponse<GetSalaryTypeListResponse> GetSalaryTypesList()
        {
            return _parametersService.GetSalaryTypeList();
        }
        public IResponse<GetCountryListResponse> GetCountryList()
        {
            return _parametersService.GetCountryList();
        }
        public IResponse<GetCitiesListByCountryIDResponse> GetCitiesListByCountryID(int? countryID)
        {
            return _parametersService.GetCitiesListByCountryID(countryID);
        }
    }
}
