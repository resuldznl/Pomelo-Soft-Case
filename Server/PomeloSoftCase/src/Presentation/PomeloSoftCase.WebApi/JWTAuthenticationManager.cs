using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PomeloSoftCase.Application.DTOs;
using PomeloSoftCase.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.WebApi
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public JWTAuthenticationManager(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public async Task<UserLoginModel> Authenticate(LoginModel loginModel)
        {
            var user = await _userService.UserLoginControl(loginModel);
            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_configuration["TokenKey"].ToString());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.Now.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            user.Token = tokenHandler.WriteToken(token);
            return user;
        }
    }
}
