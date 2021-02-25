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
        IResponse<GetFineTypeListResponse> GetFineTypeList();
        IResponse<GetForgivenessTypeListResponse> GetForgivenessTypeList();
        IResponse<GetDeviceTypeListResponse> GetDeviceTypeList();
        IResponse<GetDeviceLocationInBranchListResponse> GetDeviceLocationInBranchListResponse();
        IResponse<AddForgivenessTypeResponse> AddForgivenessType(AddForgivenessTypeRequest model);
        IResponse<EditForgivenessTypeResponse> EditForgivenessType(EditForgivenessTypeRequest model);
        IResponse<AddDepartmentResponse> AddDepartment(AddDepartmentRequest model);
        IResponse<EditDeparmentResponse> EditDepartment(EditDepartmentRequest model);
        IResponse<AddSalaryTypeResponse> AddSalaryType(AddSalaryTypeRequest model);
        IResponse<EditSalaryTypeResponse> EditSalaryType(EditSalaryTypeRequest model);
        IResponse<AddEmployeePositionResponse> AddEmployeePosition(AddEmployeePositionRequest model);
        IResponse<EditEmployeePositionResponse> EditEmployeePosition(EditEmployeePositionRequest model);
        IResponse<AddFineTypeResponse> AddFineType(AddFineTypeRequest model);
        IResponse<EditFineTypeResponse> EditFineType(EditFineTypeRequest model);
        IResponse<AddDeviceLocationInBranchResponse> AddDeviceLocationInBranch(AddDeviceLocationInBranchRequest model);
        IResponse<EditDeviceLocationInBranchResponse> EditDeviceLocationInBranch(EditDeviceLocationInBranchRequest model);
        IResponse<AddBranchResponse> AddBranch(AddBranchRequest model);
        IResponse<EditBranchResponse> EditBranch(EditBranchRequest model);
        IResponse<GetHolidayTypesListResponse> GetHolidayTypeList();
    }
}
