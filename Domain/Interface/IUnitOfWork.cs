using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUnitOfWork
    {
        IBaseRepository<T> GetRepository<T>() where T : class;
        IBranchRepository BranchRepository { get; }
        ICityRepository CityRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        IDepartmentsRepository DepartmentsRepository { get; }
        IEmployeeMobileNumbersRepository EmployeeMobileNumbersRepository { get; }
        IEmployeePositionRepositoy EmployeePositionRepositoy { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IEmpoyeeDetaisRepository EmpoyeeDetaisRepository { get; }
        ISalaryRepository SalaryRepository { get; }


        void Commit();
    }
}
