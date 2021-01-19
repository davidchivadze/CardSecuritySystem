using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUnitOfWork
    {
        IBaseRepository<T> GetRepository<T>() where T : BaseModel;
        IBranchRepository BranchRepository { get; }
        ICityRepository CityRepository { get; }
        ISalaryRepository SalaryRepository { get; }
        ISalaryTypeRepository SalaryTypeRepository { get; }
        IFineRepository FineRepository { get; }
        IFineTypeRepository FineTypeRepository { get; }
        IForgivenessRepository ForgivenessRepository { get; }
        IForgivenessTypeRepository ForgivenessTypeRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        IDepartmentsRepository DepartmentsRepository { get; }
        IEmployeeHolidayRepository EmployeeHolidayRepository { get; }
        IEmployeeMobileNumbersRepository EmployeeMobileNumbersRepository { get; }
        IEmployeePositionRepositoy EmployeePositionRepositoy { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IEmpoyeeDetaisRepository EmpoyeeDetaisRepository { get; }
        IGenderRepository GenderRepository { get; }

        void Commit();
    }
}
