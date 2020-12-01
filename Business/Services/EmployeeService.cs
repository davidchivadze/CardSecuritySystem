using Business.Interface;
using Core.Helpers;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EmployeeService :BaseService, IEmployeeService
    {
        public IResponse<List<EmployeeViewModel>> GetAllEmployee()
        {
            var result = UnitOfWork.EmployeeRepository.GetActiveEmployees(true).Select(m=>new EmployeeViewModel() { 
             ID=m.ID,
             FirstName=m.FirsName_ka,
             LastName=m.LastName_ka,
             Country=m.Department.Description_ka,
            }).ToList();
            return Ok(result);
         
        }

        public void get()
        {
            
        }
    }
}
