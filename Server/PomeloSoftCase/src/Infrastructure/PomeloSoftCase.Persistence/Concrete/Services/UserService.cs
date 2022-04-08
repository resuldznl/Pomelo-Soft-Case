using AutoMapper;
using PomeloSoftCase.Application.DTOs;
using PomeloSoftCase.Application.Interfaces.Repositories;
using PomeloSoftCase.Application.Interfaces.Services;
using PomeloSoftCase.Domain.Entities;
using PomeloSoftCase.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Persistence.Concrete.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncryptionManager _encryptionManager;
        public UserService(IUserRepository userRepository, IMapper mapper, IEncryptionManager encryptionManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encryptionManager = encryptionManager;
        }

        public async Task<bool> CreateUser(CreateUserDto createUserDto)
        {
            createUserDto.Password = _encryptionManager.HashCreate(createUserDto.Password);
            return await _userRepository.AddAsync(_mapper.Map<User>(createUserDto));
        }
        public async Task<UserLoginModel> UserLoginControl(LoginModel login)
        {
            string encryptPass = _encryptionManager.HashCreate(login.Password);
            var userControl = await _userRepository.GetAsync(p => p.UserName == login.UserName && p.Password == encryptPass);
            return userControl != null ? new() { Id = userControl.Id , Token = "test" , UserName = userControl.UserName} : null;
        }
    }
}
