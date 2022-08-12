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
        public IActionResult Create(Music m)
        {
            if (ModelState.IsValid)
            {
                // add to the database
                _context.Musics.Add(m); // prepares insert
                _context.SaveChanges();// Executes pending insert

                //show success message on page
                ViewData["Message"] = $"{m.Title} was added successfully!";
                return View();
            }

            return View(m);
        }
    }
}
