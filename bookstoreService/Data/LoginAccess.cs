using bookstoreService.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace bookstoreService.Data
{
    public class LoginAccess
    {
        private IConfiguration _config;
        public LoginAccess(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJSONWebToken(SignIn signIn)
        {
            var userAccess = new UserAccess(_config.GetConnectionString("devConnection"));
            var user = userAccess.GetUser(signIn.Email, signIn.Password);

            if (user == null)
            {
                return null;
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
