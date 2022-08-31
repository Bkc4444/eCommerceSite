using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSite.Controllers
{
    public class MembersController : Controller
    {
        private readonly MusicStoreContext _context;

        public MembersController(MusicStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel)//this will need a using
        {
            if (ModelState.IsValid)
            {
                // Map RegisterViewModel data to member object
                Member newMember = new()
                {
                    Email = regModel.Email,
                    Password = regModel.Password,
                };

                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                // Redirect to home page
                return RedirectToAction("Index", "Home");
            }

            return View(regModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                // Check DB for credentials
                Member? m = (from member in _context.Members
                           where member.Email == loginModel.Email &&
                                 member.Password == loginModel.Password
                           select member).SingleOrDefault();

                // if exists send to homepage
                if (m != null)
                {
                    HttpContext.Session.SetString("Email", loginModel.Email);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Email or password was not found. Please try again!");
            }
            // Return page in for record is found, or ModelState is invalid
            return View(loginModel);
        }
    }
}
