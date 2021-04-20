using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class UserRepository : BaseRepository<Users>, IUserRepository
    {
        public UserRepository(Data database) : base(database)
        {
        }

        public bool CheckLogin(string token)
        {
            var user = _database.Users.Where(m => m.SessionKey == token).FirstOrDefault();
            if (user != null&&user.ExpiresOn>DateTime.Now)
            {
                user.ExpiresOn = DateTime.Now.AddHours(1);
                _database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string LoginUser(string UserName, string Password)
        {
            var user = _database.Users.Where(m => m.UserName == UserName).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("მომხმარებელი ვერ მოიძებნა");
            }
            if (user.Password != Password)
            {
                throw new Exception("პაროლი არასწორია");
            }
            var token = Guid.NewGuid().ToString();
            user.SessionKey = token;
            user.LastLogin = DateTime.Now;
            user.ExpiresOn = DateTime.Now.AddHours(1);
            _database.SaveChanges();
            return token;
        }
    }
}
