using Business.Interface;
using Core.Encryption;
using Core.Helpers;
using Microsoft.IdentityModel.Tokens;
using Models.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AuthService :BaseService, IAuthService
    {
        public IResponse<string> Login(string username,string password)
        {
            try
            {
                if (!this.CheckKeygen())
                {
                    return Fail<string>("402");
                }
                var result = UnitOfWork.UserRepository.LoginUser(username, HashGenerator.CreateMD5(password));
                string cryptoString = username + "," + ConvertToTimestamp(DateTime.Now.AddHours(1));
                return Ok(HashGenerator.EncryptString("gasagebi", cryptoString));
            }
            catch(Exception ex)
            {
                return Fail<string>(ex.Message);
            }
    
        }
        public IResponse<string> GetSerialKey()
        {
            var KeygenObject = new KeygenModel() {
             Company="Home",
             DateFrom=ConvertToTimestamp(DateTime.Now),
             DateTo= ConvertToTimestamp(DateTime.Now.AddDays(15))
            };
            string serialData = "Home," + ConvertToTimestamp(DateTime.Now) + "," + ConvertToTimestamp(DateTime.Now.AddDays(15));
            var serialized = JsonConvert.SerializeObject(KeygenObject);
            var result = HashGenerator.EncryptString("GHNCOmpanyCool", serialData);
            return Ok(result);
        }
        public IResponse<bool> UpdateSerialKey(string Key)
        {
            try {
                var deserializedKey = HashGenerator.DecryptString("GHNCOmpanyCool", Key);
                //var serialKey = JsonConvert.DeserializeObject<KeygenModel>(deserializedKey);
                var data=deserializedKey.Split(',');
            var result = UnitOfWork.KeygenRepository.UpdateKeygen(new Models.EntityModels.Keygen()
            {
                Company = data[0],
                DateFrom = ConvertToDatetime(long.Parse(data[1])),
                DateTo = ConvertToDatetime(long.Parse(data[2])),
                IsActive = true,
                KeyGen = Key
            });
            return Ok(result);
            }catch(Exception ex)
            {
                return Fail<bool>(ex.Message);
            }


        }

        public static long ConvertToTimestamp(DateTime value)
        {
            TimeZoneInfo NYTimeZone = TimeZoneInfo.Local;
            DateTime NyTime = TimeZoneInfo.ConvertTime(value, NYTimeZone);
            TimeZone localZone = TimeZone.CurrentTimeZone;
            System.Globalization.DaylightTime dst = localZone.GetDaylightChanges(NyTime.Year);
            NyTime = NyTime.AddHours(-1);
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            TimeSpan span = (NyTime - epoch);
            return (long)Convert.ToDouble(span.TotalSeconds);
        }
        public static DateTime ConvertToDatetime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public bool CheckLogin(string token)
        {
            try
            {
                return UnitOfWork.UserRepository.CheckLogin(token);
            }catch(Exception ex)
            {
                return false;
            }
        }
    
        public bool CheckKeygen()
        {
            try { 
            var keyGen = UnitOfWork.KeygenRepository.GetActiveKeygen();
            if (keyGen == null)
            {
                return false;
            }
           
            var serialKey = HashGenerator.DecryptString("GHNCOmpanyCool",keyGen.KeyGen).Split(',');
                var DateFrom = ConvertToDatetime(long.Parse(serialKey[1]));
                var DateTo = ConvertToDatetime(long.Parse(serialKey[2]));
                if (DateFrom<=DateTime.Now&& DateTo>= DateTime.Now
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                return false;
            }


        }

        private string createToken(string username)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.Now;
            //set the time when it expires
            DateTime expires = DateTime.Now.AddDays(15);

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim("username", username)
            });

            const string sec = "4423654789654789";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(
                        subject: claimsIdentity,

                        signingCredentials: signingCredentials
                        );
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}

