using Business.Interface;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RestAPI.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        private IAuthService authService;
        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }


        [AllowAnonymous]
        public IResponse<string> Login(string username,string password)
        {

            return authService.Login(username,password);
        }
        [System.Web.Mvc.Authorize]
        public IResponse<string> GetSerialKey()
        {
            return authService.GetSerialKey();
        }
        [AllowAnonymous]
        public IResponse<bool> UpdateSerialKey(string key)
        {
            return authService.UpdateSerialKey(key);
        }

    }
}