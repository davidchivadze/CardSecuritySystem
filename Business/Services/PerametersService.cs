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
    }
}
