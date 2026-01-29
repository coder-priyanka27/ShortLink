using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortLink.Client.Data.ViewModels;
using ShortLink.Client.Helpers.Roles;
using ShortLink.Data;
using ShortLink.Data.Models;
using ShortLink.Data.Services;
using System.Xml.Linq;

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
            return View(new ConfirmEmailLoginViewModel());
        }
        public async Task<IActionResult> LoginSubmitted(ConfirmEmailLoginViewModel loginViewModel)
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
                    else if(userLoggedIn.IsNotAllowed)
                    {
                        return RedirectToAction("EmailConfirmation");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login attempt. Please, check your username and password");
                        return View("Login", loginViewModel);
                    }
                }
                else
                {
                    await _userManager.AccessFailedAsync(user);

                    if(await _userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("", "Your account is locked, please try again in 10 mins");
                        return View("Login", loginViewModel);
                    }
                    ModelState.AddModelError("", "Invalid login attempt. Please check your username and password");
                    return View("Login", loginViewModel);
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

            //Check if the user exists
            var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
            if (user != null)
            {
                ModelState.AddModelError("", "Email address is already in use");
                return View("Register", registerViewModel);
            }

            var newUser = new AppUser()
            {
                Email = registerViewModel.EmailAddress,
                UserName = registerViewModel.EmailAddress,
                FullName = registerViewModel.FullName,
                LockoutEnabled = true
            };

            var userCreated = await _userManager.CreateAsync(newUser, registerViewModel.Password);
            if (userCreated.Succeeded)
            { 
                await _userManager.AddToRoleAsync(newUser, Role.User);

                //Login the User
                await _signInManager.PasswordSignInAsync(newUser, registerViewModel.Password, false, false);
            }
            else
            {
                foreach(var error in userCreated.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("Register", registerViewModel);
            }

                return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> EmailConfirmation()
        {
            var confirmEmail = new ConfirmEmailLoginViewModel();
            return View(confirmEmail);

        }
    }
}
