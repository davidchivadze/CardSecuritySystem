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
    public class DeviceUserLogRepository : BaseRepository<DeviceUserLog>, IDeviceUserLogRepository
    {
        public DeviceUserLogRepository(Data database) : base(database)
        {
        }

        public bool AddLogList(List<DeviceUserLog> addList)
        {
            try
            {
                _database.DeviceUserLogs.AddRange(addList);
                _database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.InnerException);
            }
        }
        public List<DeviceAndDbUsersJoin> GetDeviceUserLogs()
        {
            try
            {
                var result = (from userLogin in _database.DeviceUserLogs
                              join employee in _database.Employees on userLogin.IndRegID equals employee.UserIDInDevice
                              select new DeviceAndDbUsersJoin
                              {
                                  FirsName = employee.FirsName,
                                  LastName = employee.LastName,
                                  MachineNumber = userLogin.MachineNumber,
                                  PersonalNumber = employee.PersonalNumber,
                                  RecordTime = userLogin.DateTimeRecord,
                                  UserIDInDevice = employee.UserIDInDevice,
                                  VerifyMode = userLogin.dwVerifyMode
                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
