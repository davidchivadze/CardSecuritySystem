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
            var result = EmployeeRepository.GetActiveEmployee().Select(m=>new EmployeeViewModel() { 
             ID=m.ID,
             FirstName=m.Employee.FirsName,
             LastName=m.Employee.LastName
            }).ToList();
            return Ok(result);
         
        }
    }
}
