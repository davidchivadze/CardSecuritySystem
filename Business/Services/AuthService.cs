using Business.Interface;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AuthService :BaseService, IAuthService
    {
        public IResponse<string> Login(string username,string password)
        {
            if (username == "admin" && password == "admin") { 
            var token=Core.TokenManagment.TokenManagment.GenerateToken("daviti", 15);
                return Ok(token);
            }
            else
            {
                return Fail<string>("მომხმარებლის სახლი ან პაროლი არასწორია");
            }
    
        }
    }
}
