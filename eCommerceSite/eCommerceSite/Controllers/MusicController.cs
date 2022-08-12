using Microsoft.AspNetCore.Mvc;

namespace eCommerceSite.Controllers
{
    public class MusicController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
