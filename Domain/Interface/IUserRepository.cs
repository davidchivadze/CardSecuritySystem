using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUserRepository:IBaseRepository<Users>
    {
        string LoginUser(string UserName, string Password);
        bool CheckLogin(string token);

    }
}
