using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealCat.API.Helpers;
using RealCat.API.Repository;
using RealCat.Core.ViewModel;

namespace RealCat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;

        public AuthorizationController(IOptions<AppSettings> appSettings, IUserRepository userRepository)
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateToken(AuthenticateRequest authenticateRequest)
        {
            var user = await _userRepository.GetByUsername(authenticateRequest.Username);
            if (user == null) return null;

            var authenticateResponse = new AuthenticateResponse(AuthorizeHelper.GenerateToken(user, _appSettings));
            return Ok(authenticateResponse);
        }
    }
}
