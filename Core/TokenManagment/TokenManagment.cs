using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Core.TokenManagment
{
    public class TokenManagment
    {
        public static string SecretKey = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1==";
        public static string GenerateToken(string UserName,int UserID) {


            //byte[] key = Convert.FromBase64String(SecretKey);

            //SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

            //JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            //JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            //return handler.WriteToken(token);
            // Define const Key this should be private secret key  stored in some safe place
            string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

           // Create Security key  using private key above:
           // not that latest version of JWT using Microsoft namespace instead of System
            var securityKey = new Microsoft
               .IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, UserName), new Claim(ClaimTypes.NameIdentifier, UserID.ToString()) }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            // Also note that securityKey length should be >256b
            // so you have to make sure that your private key has a proper length
            //
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256Signature);

            //  Finally create a Token
            var header = new JwtHeader(credentials);

            //Some PayLoad that contain information about the  customer
            var payload = new JwtPayload
           {
               { "some ", "hello "},
               { "scope", "http://dummy.com/"},
           };

            //
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            // Token to String so you can use it in your client
            var tokenString = handler.WriteToken(secToken);
            return tokenString;


        }
        public static ClaimsPrincipal GetClaimsPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
               
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadJwtToken(token);
                if (jwtToken == null)
                {
                    return null;
                }
                byte[] key = Encoding.UTF8.GetBytes(SecretKey);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = new ClaimsPrincipal();
                return principal;

            }catch(Exception ex)
            {
                return null;
            }
        }
        public static Dictionary<string,string> ValidateToken(string token)
        {
            string username = null;
            string UserID = null;
            ClaimsPrincipal principal = GetClaimsPrincipal(token);
            if (principal == null)
            {
                return null;
            }
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            username = identity.FindFirst(ClaimTypes.Name)?.Value;
            UserID = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("Username", username);
            dictionary.Add("UserID", UserID);
            return dictionary;
        }
    }
}
