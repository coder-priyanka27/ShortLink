using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortLink.Client.Data.ViewModels;
using ShortLink.Data;
using ShortLink.Data.Models;
using ShortLink.Data.Services;

namespace ShortLink.Client.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUsersService _usersService;
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        public UserAuthenticationController(IUsersService usersService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        { 
            _usersService = usersService;
            _signInManager = signInManager;
            _userManager = userManager;
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

            var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);
            if(user != null)
            {
                var userPasswordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if(userPasswordCheck)
                {
                    var userLoggedIn = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                    if(userLoggedIn.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login attempt. Please, check your username and password");
                        return View("Login", loginViewModel);
                    }
                }
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
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
