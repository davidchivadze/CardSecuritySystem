using Business.Interface;
using Core.Helper;
using Core.Helper.RepositoryHelperClasses;
using Core.Helpers;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public IResponse<List<EmployeeViewModel>> GetFilteredEmployees()
        {
            var result = UnitOfWork.EmployeeRepository.GetFilteredEmployees(new EmployeeFilter() { }).Select(m=> Transformer.EmployeeAsViewModel(m)).ToList();
            return Ok(result);
         
        }

        public void get()
        {
            
        }
    }
}
