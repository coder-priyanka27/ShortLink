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
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
