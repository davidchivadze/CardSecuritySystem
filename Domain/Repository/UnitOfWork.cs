using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Data _database;

        #region variables For Lazey Loading
        private IBranchRepository _branchRepository ;
        private ICityRepository _cityRepository;
        private ICountryRepository _countryRepository;
        private ICurrencyRepository _currencyRepository;
        private IDepartmentsRepository _departmentsRepository;
        private IEmployeeMobileNumbersRepository _employeeMobileNumbersRepository;
        private IEmployeePositionRepositoy _employeePositionRepositoy;
        private IEmployeeRepository _employeeRepository;
        private IEmpoyeeDetaisRepository _empoyeeDetaisRepository;
        private ISalaryRepository _salaryRepository;

        public IBranchRepository BranchRepository
        {
            get { return _branchRepository = _branchRepository ?? new BranchRepository(_database); }
        }

        public ICityRepository CityRepository
        {
            get { return _cityRepository = _cityRepository ?? new CityRepository(_database); }
        }

        public ICountryRepository CountryRepository
        {
            get { return _countryRepository = _countryRepository ?? new CountryRepository(_database); }
        }

        public ICurrencyRepository CurrencyRepository
        {
            get { return _currencyRepository = _currencyRepository ?? new CurrencyRepository(_database); }
        }

        public IDepartmentsRepository DepartmentsRepository
        {
            get { return _departmentsRepository = _departmentsRepository ?? new DepartmentsRepository(_database); }
        }

        public IEmployeeMobileNumbersRepository EmployeeMobileNumbersRepository
        {
            get { return _employeeMobileNumbersRepository = _employeeMobileNumbersRepository ?? new EmployeeMobileNumbersRepository(_database); }
        }

        public IEmployeePositionRepositoy EmployeePositionRepositoy
        {
            get { return _employeePositionRepositoy = _employeePositionRepositoy ?? new EmployeePositionRepository (_database); }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get { return _employeeRepository = _employeeRepository ?? new EmployeeRepository(_database); }
        }

        public IEmpoyeeDetaisRepository EmpoyeeDetaisRepository
        {
            get { return _empoyeeDetaisRepository = _empoyeeDetaisRepository ?? new EmployeeDetailsRepository(_database); }
        }

        public ISalaryRepository SalaryRepository
        {
            get { return _salaryRepository = _salaryRepository ?? new SalaryRepository(_database); }
        }
        #endregion

        public void Commit()
        {
            _database.SaveChanges();
        }

        public IBaseRepository<T> GetRepository<T>() where T : BaseModel
        {
            return new BaseRepository<T>(_database);
        }
    }
}
