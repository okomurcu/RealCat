using Microsoft.AspNetCore.Mvc;
using RealCat.API.Helpers;
using RealCat.API.Services;

namespace RealCat.API.Controllers
{
    [ApiController]
    [Route("api/cats")]
    public class CatController : ControllerBase
    {
        private readonly ICatService _catService;
        private const string ContentType = "image/jpeg";

        public CatController(ICatService catService)
        {
            _catService = catService;
        }

        [Authorize]
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return File(await _catService.Get(), ContentType);
        }

        [Authorize]
        [HttpGet("upside_down")]
        public async Task<IActionResult> GetUpsideDown()
        {
            return File(await _catService.GetUpsideDown(), ContentType);
        }
        
        [HttpGet("custom_rotation")]
        public async Task<IActionResult> GetWithCustomRotation(string rotation)
        {
            var rotations = new List<string> { "0", "90", "180", "270" };

            if (rotations.Any(s => rotation.ToLower().Contains(s)))
                return File(await _catService.GetWithCustomRotation(rotation), ContentType);

            return BadRequest($"Please use pre-defined rotation degrees. Rotations: {string.Join(", ", rotations)}");
        }

        [Authorize]
        [HttpGet("filter")]
        public async Task<IActionResult> GetWithimageFilter(string imageFilter)
        {
            var filterList = new List<string> { "blur", "mono", "sepia", "negative", "paint", "pixel" };

            if (filterList.Any(s => imageFilter.ToLower().Contains(s)))
                return File(await _catService.GetWithImageFilter(imageFilter), ContentType);

            return BadRequest($"Please use pre-defined filter values: {string.Join(",", filterList)}");
        }

        [Authorize]
        [HttpGet("width_and_height")]
        public async Task<IActionResult> GetWithWidthAndHeight(int width, int height)
        {
            if (width > 0 && height > 0)
                return File(await _catService.GetWithWidthAndHeight(width, height), ContentType);

            return BadRequest($"Width and height values must be greater than zero.");
        }
    }
}
