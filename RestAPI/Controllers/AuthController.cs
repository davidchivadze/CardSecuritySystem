using Business.Interface;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RestAPI.Controllers
{
    public class AuthController : ApiController
    {
        private IAuthService authService;
        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }
        public IResponse<string> Login(string username,string password)
        {
            
            return authService.Login(username,password);
        }
    }
}