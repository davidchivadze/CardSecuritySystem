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
        public IResponse<GetBranchListItem> GetBranchForEdit(int id)
        {
            var result = UnitOfWork.BranchRepository.GetBranches().Where(m => m.ID == id).FirstOrDefault();
            if (result != null)
            {
                return Ok(ParametersTransformer.AsViewModel(result));
            }
            else
            {
                return Fail<GetBranchListItem>("Branch Not Found");
            }
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

        public IResponse<GetHolidayTypesListResponse> GetHolidayTypeList()
        {
            var result = UnitOfWork.HolidayTypesRepository.GetHolidayTypes().Select(m => m.AsViewModel());
            return Ok(new GetHolidayTypesListResponse() { HolidayTypes=result.ToList() });
             
        }
        public IResponse<AddDepartmentResponse> AddDepartment(AddDepartmentRequest model)
        {
            try
            {
                var result = UnitOfWork.DepartmentsRepository.AddDepartment(model.AsDatabaseModel());
                if (result != null)
                {
                    return Ok(new AddDepartmentResponse() { });
                }
                else
                {
                    return Fail<AddDepartmentResponse>("ვერ მოხერხდა დეპარტამენტის დამატება");
                }
            }
            catch (Exception ex)
            {
                return Fail<AddDepartmentResponse>(ex.Message);
            }
        }

        public IResponse<EditDeparmentResponse> EditDepartment(EditDepartmentRequest model)
        {
            var result = UnitOfWork.DepartmentsRepository.EditDepartment(model.AsDatabaseModel());
            if (result != null)
            {
                return Ok(new EditDeparmentResponse() { });
            }
            else
            {
                return Fail<EditDeparmentResponse>("დეპარტამენტის რედაქტირება ვერ მოხერხდა");
            }
        }
        public IResponse<AddSalaryTypeResponse> AddSalaryType(AddSalaryTypeRequest model)
        {
            try
            {
                var result = UnitOfWork.SalaryTypeRepository.AddSalaryType(model.AsDatabaseModel());
                if (result != null)
                {
                    return Ok(new AddSalaryTypeResponse() { });
                }
                else
                {
                    return Fail<AddSalaryTypeResponse>("ვერ მოხერხდა ხელფასის ტიპის დამატება");
                }
            }
            catch (Exception ex)
            {
                return Fail<AddSalaryTypeResponse>(ex.Message);
            }
        }

        public IResponse<EditSalaryTypeResponse> EditSalaryType(EditSalaryTypeRequest model)
        {
            var result = UnitOfWork.SalaryTypeRepository.EditSalaryType(model.AsDatabaseModel());
            if (result != null)
            {
                return Ok(new EditSalaryTypeResponse() { });
            }
            else
            {
                return Fail<EditSalaryTypeResponse>("ხელფასის ტიპის რედაქტირება ვერ მოხერხდა");
            }
        }
        public IResponse<AddEmployeePositionResponse> AddEmployeePosition(AddEmployeePositionRequest model)
        {
            try
            {
                var result = UnitOfWork.EmployeePositionRepositoy.AddEmployeePosition(model.AsDatabaseModel());
                if (result != null)
                {
                    return Ok(new AddEmployeePositionResponse() { });
                }
                else
                {
                    return Fail<AddEmployeePositionResponse>("ვერ მოხერხდა თანამდებობის დამატება");
                }
            }
            catch (Exception ex)
            {
                return Fail<AddEmployeePositionResponse>(ex.Message);
            }
        }

        public IResponse<EditEmployeePositionResponse> EditEmployeePosition(EditEmployeePositionRequest model)
        {
            var result = UnitOfWork.EmployeePositionRepositoy.EditEmployeePosition(model.AsDatabaseModel());
            if (result != null)
            {
                return Ok(new EditEmployeePositionResponse() { });
            }
            else
            {
                return Fail<EditEmployeePositionResponse>("თანამდებობის რედაქტირება ვერ მოხერხდა");
            }
        }
        public IResponse<AddFineTypeResponse> AddFineType(AddFineTypeRequest model)
        {
            try
            {
                var result = UnitOfWork.FineTypeRepository.AddFineType(model.AsDatabaseModel());
                if (result != null)
                {
                    return Ok(new AddFineTypeResponse() { });
                }
                else
                {
                    return Fail<AddFineTypeResponse>("ვერ მოხერხდა ჯარიმის ტიპის დამატება");
                }
            }
            catch (Exception ex)
            {
                return Fail<AddFineTypeResponse>(ex.Message);
            }
        }

        public IResponse<EditFineTypeResponse> EditFineType(EditFineTypeRequest model)
        {
            var result = UnitOfWork.FineTypeRepository.EditFineType(model.AsDatabaseModel());
            if (result != null)
            {
                return Ok(new EditFineTypeResponse() { });
            }
            else
            {
                return Fail<EditFineTypeResponse>("ჯარიმის ტიპის რედაქტირება ვერ მოხერხდა");
            }
        }
        public IResponse<AddDeviceLocationInBranchResponse> AddDeviceLocationInBranch(AddDeviceLocationInBranchRequest model)
        {
            try
            {
                var result = UnitOfWork.DeviceLocationInBranchRepository.AddDeviceLocationInBranch(model.AsDatabaseModel());
                if (result != null)
                {
                    return Ok(new AddDeviceLocationInBranchResponse() { });
                }
                else
                {
                    return Fail<AddDeviceLocationInBranchResponse>("ვერ მოხერხდა მოწყობილობის ლოკაციის დამატება");
                }
            }
            catch (Exception ex)
            {
                return Fail<AddDeviceLocationInBranchResponse>(ex.Message);
            }
        }

        public IResponse<EditDeviceLocationInBranchResponse> EditDeviceLocationInBranch(EditDeviceLocationInBranchRequest model)
        {
            var result = UnitOfWork.DeviceLocationInBranchRepository.EditDeviceLocationInBranch(model.AsDatabaseModel());
            if (result != null)
            {
                return Ok(new EditDeviceLocationInBranchResponse() { });
            }
            else
            {
                return Fail<EditDeviceLocationInBranchResponse>("მოწყობილობის ლოკაციის რედაქტირება ვერ მოხერხდა");
            }
        }
        public IResponse<AddBranchResponse> AddBranch(AddBranchRequest model)
        {
            try
            {
                var result = UnitOfWork.BranchRepository.AddBranch(model.AsDatabaseModel());
                if (result != null)
                {
                    return Ok(new AddBranchResponse() { });
                }
                else
                {
                    return Fail<AddBranchResponse>("ვერ მოხერხდა ფილიალის დამატება");
                }
            }
            catch (Exception ex)
            {
                return Fail<AddBranchResponse>(ex.Message);
            }
        }

        public IResponse<EditBranchResponse> EditBranch(EditBranchRequest model)
        {
            var result = UnitOfWork.BranchRepository.EditBranch(model.AsDatabaseModel());
            if (result != null)
            {
                return Ok(new EditBranchResponse() { });
            }
            else
            {
                return Fail<EditBranchResponse>("ფილიალის რედაქტირება ვერ მოხერხდა");
            }
        }
    }
}
