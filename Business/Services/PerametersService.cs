using Business.Interface;
using Core.Helper;
using Core.Helpers;
using Models.ViewModels.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PerametersService : BaseService, IParametersService
    {
        public IResponse<GetDepartmentsListResponse> GetDepartmentsList()
        {
            var result = UnitOfWork.DepartmentsRepository.GetDepartments().Select(m => m.AsViewModel()).ToList();
            return Ok<GetDepartmentsListResponse>(new GetDepartmentsListResponse()
            {
                DepartmentsList = result
            });
        }

        public IResponse<GetGenderListResponse> GetGenderList()
        {
            var result = UnitOfWork.GenderRepository.GetGenders().Select(m=>m.AsViewModel()).ToList();
            return Ok<GetGenderListResponse>(new GetGenderListResponse()
            {
                GenderList = result
            });
            
        }
        public IResponse<GetBranchListResponse> GetBranchList()
        {
            var result = UnitOfWork.BranchRepository.GetBranches().Select(m => ParametersTransformer.AsViewModel(m)).ToList();
            return Ok<GetBranchListResponse>(new GetBranchListResponse()
            {
                BranchList = result
            });
        }

        public IResponse<GetEmployeePositionsResponse> GetEmployeePositionsList()
        {
            var result = UnitOfWork.EmployeePositionRepositoy.GetEmployeePositions().Select(m => m.AsViewModel()).ToList();
            return Ok<GetEmployeePositionsResponse>(new GetEmployeePositionsResponse()
            {
                getEmployeePositionsList = result
            });
        }

        public IResponse<GetCountryListResponse> GetCountryList()
        {
            var result = UnitOfWork.CountryRepository.GetCountries().Select(m => ParametersTransformer.AsViewModel(m)).ToList();
            return Ok(new GetCountryListResponse()
            {
                CountryList = result
            });
        }

        public IResponse<GetCitiesListByCountryIDResponse> GetCitiesListByCountryID(int? countryID)
        {
            var result = UnitOfWork.CityRepository.GetCitiesByCountryID(countryID).Select(m => ParametersTransformer.AsViewModel(m)).ToList();
            return Ok(new GetCitiesListByCountryIDResponse()
            {
                CitiesList = result
            });
        }

        public IResponse<GetSalaryTypeListResponse> GetSalaryTypeList()
        {
            var result = UnitOfWork.SalaryTypeRepository.GetSalarieTypes().Select(m=>m.AsViewModel());
            return Ok(new GetSalaryTypeListResponse()
            {
                SalaryTypes = result.ToList()
            }); 
        }
        public IResponse<GetFineTypeListResponse> GetFineTypeList()
        {
            var result = UnitOfWork.FineTypeRepository.GetFineTypes().Select(m => m.AsViewModel());
            return Ok(new GetFineTypeListResponse()
            {
                FineTypes = result.ToList()
            }); 
        }
        public IResponse<GetForgivenessTypeListResponse> GetForgivenessTypeList()
        {
            var result = UnitOfWork.ForgivenessTypeRepository.GetForgivenessTypes().Select(m => m.AsViewModel());
            return Ok(new GetForgivenessTypeListResponse()
            {
                ForgivenessTypes = result.ToList()
            });
        }
        public IResponse<GetDeviceTypeListResponse> GetDeviceTypeList()
        {
            try { 
            var result = UnitOfWork.DeviceTypeRepository.GetDeviceTypes().Select(m=>m.AsViewModel());
            return Ok(new GetDeviceTypeListResponse() { DeviceTypeList = result.ToList() });
            }catch(Exception ex)
            {
                return Fail<GetDeviceTypeListResponse>(ex.Message);
            }
        }

        public IResponse<GetDeviceLocationInBranchListResponse> GetDeviceLocationInBranchListResponse()
        {
            try { 
            var result = UnitOfWork.DeviceLocationInBranchRepository.GetDeviceLocationInBranches().Select(m => m.AsViewModel());
            return Ok(new GetDeviceLocationInBranchListResponse()
            {
                DeviceLocationInBranchList = result.ToList()
            });
            }catch(Exception ex)
            {
                return Fail<GetDeviceLocationInBranchListResponse>(ex.Message);
            }
        }

        public IResponse<AddForgivenessTypeResponse> AddForgivenessType(AddForgivenessTypeRequest model)
        {
            try
            {
                var result = UnitOfWork.ForgivenessTypeRepository.AddForgivenessType(model.AsDatabaseModel());
                if (result != null)
                {
                    return Ok(new AddForgivenessTypeResponse() { });
                }
                else
                {
                    return Fail<AddForgivenessTypeResponse>("ვერ მოხერხდა პატიების დამატება");
                }
            }catch(Exception ex)
            {
                return Fail<AddForgivenessTypeResponse>(ex.Message);
            }
        }

        public IResponse<EditForgivenessTypeResponse> EditForgivenessType(EditForgivenessTypeRequest model)
        {
            var result = UnitOfWork.ForgivenessTypeRepository.EditForgivenessType(model.AsDatabaseModel());
            if (result != null)
            {
                return Ok(new EditForgivenessTypeResponse() { });
            }
            else
            {
                return Fail<EditForgivenessTypeResponse>("");
            }
        }
    }
}
