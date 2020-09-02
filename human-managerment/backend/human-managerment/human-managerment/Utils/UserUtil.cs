
using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Utils
{
    public class UserUtil
    {
        private IConfiguration _config;
        public UserUtil(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateJSONWebToken(UserDTO userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Jwt:key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            string userResources = RetriveResource(userInfo);

            var claims = new[] {
                  new Claim(SecurityContant.USER_NAME_CLAIMS, userInfo.username),
                  new Claim(SecurityContant.USER_RESOURCE_CLAIMS, userResources),     
            };

            var token = new JwtSecurityToken(_config.GetValue<string>("Jwt:Issuer"),
              _config.GetValue<string>("Jwt:Issuer"),
              claims,
              null,
              expires: DateTime.Now.AddMinutes(int.Parse(_config.GetValue<string>("Jwt:expired"))),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string RetriveResource(UserDTO userInfo)
        {
           string result = "";
            userInfo.UserRoles.ForEach(ur => {
                ur.Role.ResourceRoles.ForEach(rr => {
                    result += rr.Resource.Name;
                    result += SecurityContant.ACTION_REQUESTMETHOD_SEPARATOR + rr.permissions + SecurityContant.ACTION_SEPARATOR;
                });
            });
           return result;
        }
    }
}
