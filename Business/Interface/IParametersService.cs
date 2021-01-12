using Core.Helpers;
using Models.ViewModels.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IParametersService
    {
        IResponse<GetGenderListResponse> GetGenderList();
        IResponse<GetDepartmentsListResponse> GetDepartmentsList();
        IResponse<GetBranchListResponse> GetBranchList();
        IResponse<GetEmployeePositionsResponse> GetEmployeePositionsList();
        IResponse<GetCountryListResponse> GetCountryList();
        IResponse<GetCitiesListByCountryIDResponse> GetCitiesListByCountryID(int? countryID);
        IResponse<GetSalaryTypeListResponse> GetSalaryTypeList();
    }
}
