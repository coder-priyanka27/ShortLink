using Microsoft.AspNetCore.Mvc;
using ShortLink.Client.Data.ViewModels;
using ShortLink.Data;

namespace ShortLink.Client.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private AppDbContext _context;
        public UserAuthenticationController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Users()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        public IActionResult LoginSubmitted(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View("Login", loginViewModel);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        public IActionResult RegisterUser(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) {
                return View("Register", registerViewModel);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
