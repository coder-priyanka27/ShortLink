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
        public async Task<IActionResult> Users()
        {
            var users = await _usersService.GetUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> Login()
        {
            return View(new LoginViewModel());
        }
        public async Task<IActionResult> LoginSubmitted(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View("Login", loginViewModel);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Register()
        {
            return View(new RegisterViewModel());
        }
        public async Task<IActionResult> RegisterUser(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) {
                return View("Register", registerViewModel);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
