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
        ICurrencyTypeRepository CurrencyTypeRepository { get; }
        IDepartmentsRepository DepartmentsRepository { get; }
        IEmployeeListRepository EmployeeListRepository { get; }
        IEmployeeHolidayRepository EmployeeHolidayRepository { get; }
        IEmployeeHolidayRequestRepository EmployeeHolidayRequestRepository { get; }
        IGovernmentHolidaysRepository GovernmentHolidaysRepository { get; }
        IEmployeeMobileNumbersRepository EmployeeMobileNumbersRepository { get; }
        IEmployeePositionRepositoy EmployeePositionRepositoy { get; }
        IEmployeeRepository EmployeeRepository { get; }
         IScheduleGeneratorRepository ScheduleGeneratorRepository { get; }
        IEmpoyeeDetaisRepository EmpoyeeDetaisRepository { get; }
        IKeygenRepository KeygenRepository { get; }
        IGenderRepository GenderRepository { get; }
        IUserRepository UserRepository { get; }
        IDeviceTypeRepository DeviceTypeRepository { get; }
        IRemoteDeviceSyncLogRepository RemoteDeviceSyncLogRepository { get; }
        IDeviceRepository DeviceRepository { get; }
        IDeviceLocationInBranchRepository DeviceLocationInBranchRepository { get; }
        IDeviceUserLogRepository DeviceUserLogRepository { get; }

        IDeviceRegistratedUsersRepository DeviceRegistratedUsersRepository { get; }
        IHolidayTypesRepository HolidayTypesRepository { get; }

        void Commit();
    }
}
