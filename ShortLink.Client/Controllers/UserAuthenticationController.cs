using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
