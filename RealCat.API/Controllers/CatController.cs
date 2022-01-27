using Microsoft.AspNetCore.Mvc;
using RealCat.API.Helpers;
using RealCat.API.Services;

namespace RealCat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CatController : ControllerBase
    {
        private readonly ICatService _catService;
        private const string ContentType = "image/jpeg";

        public CatController(ICatService catService)
        {
            _catService = catService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return File(await _catService.GetCat(), ContentType);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUpsideDownCat()
        {
            return File(await _catService.GetUpsideDownCat(), ContentType);
        }
    }
}
