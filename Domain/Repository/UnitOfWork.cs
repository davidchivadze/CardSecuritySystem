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
        private IKeygenRepository _keygenRepository;
        private ICityRepository _cityRepository;
        private ICountryRepository _countryRepository;
        private ICurrencyRepository _currencyRepository;
        private ISalaryTypeRepository _salaryTypeRepository;
        private IFineTypeRepository _fineTypeRepository;
        private IForgivenessTypeRepository _forgivenessTypeRepository;
        private ICurrencyTypeRepository _currencyTypeRepository;
        private IDepartmentsRepository _departmentsRepository;
        private IEmployeeHolidayRepository _employeeHolidayRepository;
        private IEmployeeMobileNumbersRepository _employeeMobileNumbersRepository;
        private IEmployeePositionRepositoy _employeePositionRepositoy;
        private IEmployeeRepository _employeeRepository;
        private IEmployeeListRepository _employeeListRepository;
        private IEmpoyeeDetaisRepository _empoyeeDetaisRepository;
        private IFineRepository _fineRepository;
        private IForgivenessRepository _forgivenessRepository;
        private ISalaryRepository _salaryRepository;
        private IGenderRepository _genderRepository;
        private IBranchRepository _branchRepository;
        private IUserRepository _userRepository;

        private IDeviceTypeRepository _deviceTypeRepository;

        private IDeviceRepository _deviceRepository;
        private IRemoteDeviceSyncLogRepository _remoteDeviceSyncLogRepository;
        private IDeviceLocationInBranchRepository _deviceLocationInBranchRepository;
        private IDeviceUserLogRepository _deviceUserLogRepository;
        private IDeviceRegistratedUsersRepository _deviceRegistratedUsersRepository;
        private IHolidayTypesRepository _holidayTypesRepository;
        #endregion


        #region Constructors
        public UnitOfWork(Data database)
        {
            _database = database;
        }

        public UnitOfWork() : this(new Data()) { }
        #endregion

        #region Interface Repositories Implementation    
        public IDeviceRepository DeviceRepository
        {
            get { return _deviceRepository = _deviceRepository ?? new DeviceRepository(_database); }
        }
        public IDeviceUserLogRepository DeviceUserLogRepository
        {
            get { return _deviceUserLogRepository = _deviceUserLogRepository ?? new DeviceUserLogRepository(_database); }
        }
        public IDeviceRegistratedUsersRepository DeviceRegistratedUsersRepository
        {
            get { return _deviceRegistratedUsersRepository = _deviceRegistratedUsersRepository ?? new DeviceRegistratedUsersRepository(_database); }
        }
        public IUserRepository UserRepository
        {
            get { return _userRepository = _userRepository ?? new UserRepository(_database); }
        }
        public IKeygenRepository KeygenRepository
        {
            get { return _keygenRepository = _keygenRepository ?? new KeygenRepository(_database); }
        }
        public IDeviceTypeRepository DeviceTypeRepository
        {
            get { return _deviceTypeRepository = _deviceTypeRepository ?? new DeviceTypeRepository(_database); }
        }
        public IRemoteDeviceSyncLogRepository RemoteDeviceSyncLogRepository
        {
            get { return _remoteDeviceSyncLogRepository = _remoteDeviceSyncLogRepository ?? new RemoteDeviceSyncLogRepository(_database); }
        }
        public IDeviceLocationInBranchRepository DeviceLocationInBranchRepository
        {
            get { return _deviceLocationInBranchRepository = _deviceLocationInBranchRepository ?? new DeviceLocationInBranchRepository(_database); }
        }
        public IBranchRepository BranchRepository
        {
            get { return _branchRepository = _branchRepository ?? new BranchRepository(_database); }
        }
        public ISalaryTypeRepository SalaryTypeRepository
        {
            get { return _salaryTypeRepository = _salaryTypeRepository ?? new SalaryTypeRepository(_database); }
        }
        public IFineRepository FineRepository
        {
            get { return _fineRepository = _fineRepository ?? new FineRepository(_database); }
        }
        public IFineTypeRepository FineTypeRepository
        {
            get { return _fineTypeRepository = _fineTypeRepository ?? new FineTypeRepository(_database); }
        }
        public IForgivenessRepository ForgivenessRepository
        {
            get { return _forgivenessRepository = _forgivenessRepository ?? new ForgivenessRepository(_database); }
        }
        public IHolidayTypesRepository HolidayTypesRepository { get { return _holidayTypesRepository = _holidayTypesRepository ?? new HolidayTypesRepository(_database); } }
        public IForgivenessTypeRepository ForgivenessTypeRepository
        {
            get { return _forgivenessTypeRepository = _forgivenessTypeRepository ?? new ForgivenessTypeRepository(_database); }
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
        public IEmployeeHolidayRepository EmployeeHolidayRepository
        {
            get { return _employeeHolidayRepository = _employeeHolidayRepository ?? new EmployeeHolidayRepository(_database); }
        }

        public IEmployeePositionRepositoy EmployeePositionRepositoy
        {
            get { return _employeePositionRepositoy = _employeePositionRepositoy ?? new EmployeePositionRepository(_database); }
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
        public IGenderRepository GenderRepository
        {
            get { return _genderRepository = _genderRepository ?? new GenderRepository(_database); }
        }

        public ICurrencyTypeRepository CurrencyTypeRepository
        {
            get { return _currencyTypeRepository = _currencyTypeRepository ?? new CurrencyTypeRespository(_database); }
        }

        public IEmployeeListRepository EmployeeListRepository
        {
            get { return _employeeListRepository = _employeeListRepository ?? new EmployeeListRepository(_database); }
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
