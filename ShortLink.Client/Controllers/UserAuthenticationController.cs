using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortLink.Client.Data.ViewModels;
using ShortLink.Data;
using ShortLink.Data.Services;

namespace ShortLink.Client.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUsersService _usersService;
        public UserAuthenticationController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        public IActionResult Users()
        {
            var users = _usersService.GetUsers();
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
