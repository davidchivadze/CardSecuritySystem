using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IAuthService
    {
        IResponse<string> Login(string username,string password);
        bool CheckLogin(string token);
        IResponse<string> GetSerialKey();
        IResponse<bool> UpdateSerialKey(string Key);
        bool CheckKeygen();
    }
}
