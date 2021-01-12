using Business.Interface;
using Core.Helper;
using Core.Helper.RepositoryHelperClasses;
using Core.Helpers;
using Models.ViewModels;
using Models.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public IResponse<List<AddEmployeeRequestModel>> GetFilteredEmployees()
        {
            var result = UnitOfWork.EmployeeRepository.GetFilteredEmployees(new EmployeeFilter() { }).Select(m=> m.AsViewModel()).ToList();
            return Ok(result);
         
        }
        public IResponse<AddEmployeeResposeModel> AddEmployee(AddEmployeeRequestModel request)
        {
            try { 
            var result = UnitOfWork.EmployeeRepository.AddEmployee(request.AsDatabaseModel());
            return Ok(new AddEmployeeResposeModel() { });
            }catch(Exception ex)
            {
                return Fail<AddEmployeeResposeModel>(ex.Message);
            }
        }

        public void get()
        {
            
        }

        public IResponse<GetEmployeeHolidayListResponse> GetEmployeeHolidayList(GetEmployeeHolidayListRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
