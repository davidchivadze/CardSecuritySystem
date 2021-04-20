using Domain.Interface;
using Models.EntityModels;
using Models.LinqJoinDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(Data database) : base(database)
        {
        }

        public Device AddDevice(Device device)
        {
            try
            {
                var result = _database.Devices.Add(device);
                _database.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "; Inner Exception" + ex.InnerException);
            }
        }

        public bool DeleteDevice(int id)
        {
            var result = _database.Devices.Where(m => m.ID == id).FirstOrDefault();
            result.IsActive = false;
            _database.SaveChanges();
            return true;
        }

        public Device EditDevice(Device device)
        {
            var result = _database.Devices.Where(m => m.ID == device.ID).FirstOrDefault();
            result.DeviceTypeID = device.DeviceTypeID;
            result.DeviceLocationInBranchID = device.DeviceLocationInBranchID;
            result.NumberDevices = device.NumberDevices;
            result.IPAddress = device.IPAddress;
            result.IsActive = device.IsActive;
            result.Name = device.Name;
            result.Port = device.Port;
            result.Password = device.Password;
            result.UserName = device.UserName;
            _database.Entry<Device>(result).State = System.Data.Entity.EntityState.Modified;
            _database.SaveChanges();
            return result;
        }

        public IEnumerable<DeviceRegistratedUsersToEmployee> GetDeviceRegistratedUsers()
        {
            var result = (from dru in _database.DeviceRegistratedUsers
                          join emp in _database.Employees on dru.UserDeviceID equals emp.UserIDInDevice into sr
                          from x in sr.DefaultIfEmpty()
                          select new DeviceRegistratedUsersToEmployee
                          {
                              ID = dru.ID,
                              UserDeviceID = dru.UserDeviceID,
                              Enabled = dru.UserDeviceID == 1,
                              FingerIndex = dru.FingerIndex,
                              iFlag = dru.iFlag,
                              IsRegistratedSystem = sr.Any(),
                              MachineNumber = dru.MachineNumber,
                              Name = dru.Name,
                              Password = dru.Password,
                              Privelage = dru.Privelage,
                              TmpData = dru.TmpData

                          });
            return result;
        }

        public IEnumerable<Device> GetDevices()
        {
            try
            {
                var result = _database.Devices.Include("Branch").Include("DeviceLocationInBranch").Where(m => m.IsActive);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "; Inner Exception" + ex.InnerException);
            }
        }
    }
}
