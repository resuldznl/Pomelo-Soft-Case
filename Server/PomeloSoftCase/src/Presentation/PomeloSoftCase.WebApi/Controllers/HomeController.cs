using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PomeloSoftCase.Application.DTOs;
using PomeloSoftCase.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomeloSoftCase.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTAuthenticationManager _jWTAuthenticationManager;
        public HomeController(IUserService userService, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            _userService = userService;
            _jWTAuthenticationManager = jWTAuthenticationManager;
        }
        [Route("/Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel login)
        {
            var loginControl = await _jWTAuthenticationManager.Authenticate(login);
            return loginControl != null ? Ok(loginControl) : Unauthorized();
        }
        [Route("/SignUp")]
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody]CreateUserDto createUser)
        {
            return await _userService.CreateUser(createUser) == true ? Ok() : BadRequest();
        }
    }
}
