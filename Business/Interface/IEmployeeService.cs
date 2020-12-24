using Core.Helpers;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IEmployeeService
    {
        IResponse<List<AddEmployeeRequestModel>> GetFilteredEmployees();
        IResponse<AddEmployeeResposeModel> AddEmployee(AddEmployeeRequestModel request);
    }
}
