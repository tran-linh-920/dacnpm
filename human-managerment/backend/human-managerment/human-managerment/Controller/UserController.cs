using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using HumanManagermentBackend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HumanManagermentBackend.Controller
{
    [Route("/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserUtil _userUtil;
        private UserService _userService;
        public UserController(UserUtil userUtil, UserServiceImpl userService)
        {
            _userUtil = userUtil;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserEntity login)
        {
            IActionResult response = Unauthorized();
            var user = _userService.FindOne(login);

            if (user != null)
            {
                var tokenString = _userUtil.GenerateJSONWebToken(user);
                response = Ok(new Api<object>(200, new {username = login.Username, token = tokenString }, "Login success", null));
            }

            return response;
        }

    }
}
