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
            var result = UnitOfWork.EmployeeRepository.GetAll().ToList().Select(m=>new EmployeeViewModel() { 
             FirstName=m.FirsName,
              ID=m.ID,
               LastName=m.LastName
            }).ToList();
            return Ok(result);
         
        }
    }
}
