using Business.Interface;
using Business.Services;
using Core.Encryption;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace RestAPI.Authentification
{
    public class JwtAuthentication : AuthorizeAttribute, IAuthenticationFilter
    {
        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            Contract.Assert(actionContext != null);

            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                       || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }
        private bool? IsActiveKeygen { get; set; }
        private IAuthService authService;
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var type = context.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerType.CustomAttributes.Where(m => m.AttributeType.Name == "AllowAnonymousAttribute").FirstOrDefault();
            if (type!=null) return;
            string authParameters = string.Empty;
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
            if (authorization != null)
            {
                authParameters = authorization.Parameter;
            }
            else
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Token", request);
            }
            authService = authService ?? new AuthService();
            if (context.Request.RequestUri.AbsoluteUri.Contains("Auth/Login"))
            {
                if (!authService.CheckKeygen())
                {
                    context.ErrorResult = new AuthenticationFailureResult("402", request);
                }
            }
            if (!context.Request.RequestUri.AbsoluteUri.Contains("UpdateSerialKey"))
            {

                //var header=authorization.Parameter.FirstOrDefault();

                    try
                    {
                    if (!context.Request.RequestUri.AbsoluteUri.Contains("Auth/Login")) { 
                        HashGenerator.DecryptString("gasagebi", authParameters);
                    }
                    GenericIdentity myIdentity = new GenericIdentity("MyUser");
                        String[] myStringArray = { "Manager", "Teller" };
                        GenericPrincipal myPrincipal = new GenericPrincipal(myIdentity, myStringArray);
                        Thread.CurrentPrincipal = myPrincipal;
                        HttpContext.Current.User = myPrincipal;
                        context.Principal = myPrincipal;
                    }
                    catch (Exception ex)
                    {
                        context.ErrorResult = new AuthenticationFailureResult("Missing Token", request);
                    }
                }
                else
                {
                    context.ErrorResult = new AuthenticationFailureResult("Not Valid Serial Key", request);
                    //if (authorization == null) {

                    //    context.ErrorResult = new AuthenticationFailureResult("Missing Authorization Header", request);
                    //}
                    //else { 
                    //if (authorization==null&& authorization.Scheme != "Bearer")
                    //{
                    //    context.ErrorResult = new AuthenticationFailureResult("Invalid Authorization Scheme",request);
                    //}
                    //if (String.IsNullOrEmpty(authorization.Parameter))
                    //{
                    //    context.ErrorResult = new AuthenticationFailureResult("Missing Token", request);
                    //}

                }
            
        }
        

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var result = await context.Result.ExecuteAsync(cancellationToken);
            if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic", "realm=localhost"));
                result.Headers.Add("Access-Control-Allow-Origin", "*");
                result.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            }
            context.Result = new ResponseMessageResult(result);
        }
    }
    public class AuthenticationFailureResult : IHttpActionResult
    {
        public string ReasonPhrase;
        public HttpRequestMessage Request { get; set; }
        public AuthenticationFailureResult(string reasonPhrase,HttpRequestMessage request)
        {
            ReasonPhrase = reasonPhrase;
            Request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Exceute());
          
        }

        public HttpResponseMessage Exceute()
        {
            var statusCode = ReasonPhrase == "402" ? System.Net.HttpStatusCode.PaymentRequired : System.Net.HttpStatusCode.Unauthorized;
            HttpResponseMessage responseMessage = new HttpResponseMessage(statusCode);
            responseMessage.RequestMessage = Request;
            responseMessage.ReasonPhrase = ReasonPhrase;
            return responseMessage;
        }
    }
}