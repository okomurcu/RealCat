using Microsoft.AspNetCore.Mvc;
using RealCat.API.Helpers;
using RealCat.API.Repository;
using RealCat.Core.Model;
using RealCat.Core.Dto;

namespace RealCat.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize]
        [HttpGet("get")]
        public async Task<ActionResult<User>> Get(string username)
        {
            var user = await _userRepository.GetByUsername(username);

            if (user == null)
                return NotFound("User cannot found");

            return Ok(user);
        }

        [Authorize]
        [HttpGet("get_all")]
        public async Task<ActionResult<User>> GetAll()
        {
            var userList = _userRepository.GetAll();

            if (userList == null)
                return NotFound("User cannot found");

            return Ok(userList);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(UserCreateDto request)
        {
            var user = await _userRepository.GetByUsername(request.Username);
            if (user != null)
                return BadRequest("Username already exists");

            _userRepository.Create(request);

            return Ok("User is created");
        }
    }
}
