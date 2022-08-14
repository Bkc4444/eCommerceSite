using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSite.Controllers
{
    public class MusicController : Controller
    {
        private readonly MusicStoreContext _context;

        public MusicController(MusicStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Music m) //async then adding Task<IActionResult> will help make the load go much faster
        {
            if (ModelState.IsValid)
            {
                // add to the database
                _context.Musics.Add(m);             // prepares insert

                // When using async this needs to have an await at the front and add Async at the end of save changes
                await _context.SaveChangesAsync();  // Executes pending insert

                //show success message on page
                ViewData["Message"] = $"{m.Title} was added successfully!";
                return View();
            }

            return View(m);
        }
    }
}
