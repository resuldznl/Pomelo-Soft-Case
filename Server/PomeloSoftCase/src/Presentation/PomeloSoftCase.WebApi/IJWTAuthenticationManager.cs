using PomeloSoftCase.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomeloSoftCase.WebApi
{
    public interface IJWTAuthenticationManager
    {
        Task<UserLoginModel> Authenticate(LoginModel loginModel);
    }
}
