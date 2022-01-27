﻿using Microsoft.AspNetCore.Mvc;
using RealCat.API.Helpers;
using RealCat.API.Repository;
using RealCat.API.Services;
using RealCat.Core.Model;
using RealCat.Core.Dto;

namespace RealCat.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository, ILoginService loginService)
        {
            _loginService = loginService;
            _userRepository = userRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<User>> Get(string username)
        {
            var user = await _loginService.GetUser(username);

            if (user == null)
                return NotFound("User cannot found");

            return Ok(user);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<User>> GetAll()
        {
            var userList = _userRepository.GetAll();

            if (userList == null)
                return NotFound("User cannot found");

            return Ok(userList);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto request)
        {
            var user = await _loginService.GetUser(request.Username);
            if (user != null)
                return BadRequest("Username already exists");

            _userRepository.Create(request);

            return Ok();
        }
    }
}
