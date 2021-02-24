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
        //დეპარტამენტის დამატება
        public IResponse<GetDepartmentsListResponse> GetDepartmentsList()
        {
            return _parametersService.GetDepartmentsList();
        }
        //ბრენჩის დამატება
        public IResponse<GetBranchListResponse> GetBranchList()
        {
            return _parametersService.GetBranchList();
        }
        //პოზიციების დამატება
        public IResponse<GetEmployeePositionsResponse> GetEmployeePositionsList()
        {
            return _parametersService.GetEmployeePositionsList();
        }
        //ანაზღაურებისტიპების დამატება
        public IResponse<GetSalaryTypeListResponse> GetSalaryTypesList()
        {
            return _parametersService.GetSalaryTypeList();
        }
        //ჯარიმის ტიპის დამატება
        public IResponse<GetFineTypeListResponse> GetFineTypesLIst()
        {
            return _parametersService.GetFineTypeList();
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
        //მოწყობილობების ლოკაციების დამატება
        public IResponse<GetDeviceLocationInBranchListResponse> GetDeviceLocationInBranchList()
        {
            return _parametersService.GetDeviceLocationInBranchListResponse();
        }
        public IResponse<AddForgivenessTypeResponse> AddForgivenessType(AddForgivenessTypeRequest model)
        {
            return _parametersService.AddForgivenessType(model);
        }
        public IResponse<EditForgivenessTypeResponse> EditForgivenessType(EditForgivenessTypeRequest model)
        {
            return _parametersService.EditForgivenessType(model);
        }
    }
}
