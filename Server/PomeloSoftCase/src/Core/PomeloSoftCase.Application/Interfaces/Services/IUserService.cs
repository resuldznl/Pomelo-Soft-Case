using PomeloSoftCase.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserDto createUserDto);
        Task<UserLoginModel> UserLoginControl(LoginModel login);
    }
}
