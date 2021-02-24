using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class DeviceRegistratedUsersRepository : BaseRepository<DeviceRegistratedUsers>, IDeviceRegistratedUsersRepository
    {
        public DeviceRegistratedUsersRepository(Data database) : base(database)
        {
        }

        public bool AddDeviceRegistratedUsersList(List<DeviceRegistratedUsers> userList)
        {
            //var trans = _database.Database.BeginTransaction();
            try {
                //var trans=_database.Database.BeginTransaction();
            _database.Database.ExecuteSqlCommand(" TRUNCATE TABLE DeviceRegistratedUsers");
                _database.DeviceRegistratedUsers.AddRange(userList);
                _database.SaveChanges();
                //trans.Commit();
                return true;
            }catch(Exception ex)
            {
                //trans.Rollback();
                throw new Exception(ex.Message);
            }
        }
    }
}
