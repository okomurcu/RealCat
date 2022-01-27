using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealCat.API.Helpers;
using RealCat.API.Repository;
using RealCat.API.Services;
using RealCat.Core.Model;
using RealCat.Core.Dto;
using RealCat.Core.ViewModel;

namespace RealCat.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly ILoginService _loginService;
        private readonly IUserRepository _userService;

        public UserController(IOptions<AppSettings> appSettings,
            ILoginService loginService,
            IUserRepository userService)
        {
            _appSettings = appSettings.Value;
            _loginService = loginService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> GetToken(AuthenticateRequest authenticateRequest)
        {
            var user = await _loginService.GetUser(authenticateRequest.Username);
            if (user == null) return null;

            var authenticateResponse = new AuthenticateResponse(AuthorizeHelper.GenerateToken(user, _appSettings));
            return Ok(authenticateResponse);
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
            var userList = _userService.GetAll();

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

            _userService.Create(request);

            return StatusCode(201);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<User>> Logout(string username)
        {
            var user = await _loginService.GetUser(username);

            //TODO: Logout logic will be implemented
            if (user == null)
                return NotFound("User cannot be found");

            return Ok($"username: {user} logout successful");
        }
    }
}
