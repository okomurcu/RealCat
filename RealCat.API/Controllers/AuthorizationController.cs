using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealCat.API.Helpers;
using RealCat.API.Services;
using RealCat.Core.ViewModel;

namespace RealCat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly ILoginService _loginService;

        public AuthorizationController(IOptions<AppSettings> appSettings, ILoginService loginService)
        {
            _appSettings = appSettings.Value;
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateToken(AuthenticateRequest authenticateRequest)
        {
            var user = await _loginService.GetUser(authenticateRequest.Username);
            if (user == null) return null;

            var authenticateResponse = new AuthenticateResponse(AuthorizeHelper.GenerateToken(user, _appSettings));
            return Ok(authenticateResponse);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout(string token)
        {
            //TODO: Logout logic will be implemented

            return Ok("logout successful");
        }
    }
}
