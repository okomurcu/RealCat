using Microsoft.AspNetCore.Mvc;

namespace RealCat.API.Controllers
{
    public class CatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
