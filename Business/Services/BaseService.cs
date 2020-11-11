using Business.Interface;
using Core.Helpers;
using Domain.Interface;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public class BaseService:ServiceHelper,IBaseService
    {
        private IEmployeeRepository _EmployeeRepository { get; set; }

        protected IEmployeeRepository EmployeeRepository
        {
            get
            {
                return _EmployeeRepository = _EmployeeRepository ?? new EmployeeRepository();
            }
        }
    }
}
