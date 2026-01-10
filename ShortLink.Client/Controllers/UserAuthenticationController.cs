using Microsoft.AspNetCore.Mvc;
using ShortLink.Client.Data.ViewModels;

namespace ShortLink.Client.Controllers
{
    public class UserAuthenticationController : Controller
    {
        public IActionResult Users()
        {
            return View();
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
