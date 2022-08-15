using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceSite.Controllers
{
    public class MusicController : Controller
    {
        private readonly MusicStoreContext _context;

        public MusicController(MusicStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //get all the games from the database
            List<Music> musicList = await _context.Musics.ToListAsync();

            //or

            //List<Music> musicList = await (from music in _context.Musics
                                          //select music).ToListAsync();

            // show then on the page
            return View(musicList);

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

        public async Task<IActionResult> Edit(int id)//this in id is referencing whats in the index.cshtml asp-route-id="@item.MusicID" is what this is referencing
        {
            Music? musicToEdit = await _context.Musics.FindAsync(id);

            if(musicToEdit == null)
            {
                return NotFound();
            }

            return View(musicToEdit);// with this variable it can pull up the game to edit that was chosen
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Music musicModel)
        {
            if (ModelState.IsValid)
            {
                _context.Musics.Update(musicModel);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{musicModel.Title} was updated successfully!";//this is what is said when the update is completed
                return RedirectToAction("Index");
            }
            return View(musicModel);
        }
    }
}
