using Microsoft.AspNetCore.Mvc;
using ShortLink.Client.Data.ViewModels;
using ShortLink.Data;
using ShortLink.Data.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace ShortLink.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new PostUrlViewModel());
        }

        public IActionResult ShortenUrl(PostUrlViewModel postUrlViewModel)
        {
            // Validate the Model
            if(!ModelState.IsValid)
            {
                return View("Index", postUrlViewModel);
            }
            var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newUrl = new Url()
            {
                OriginalLink = postUrlViewModel.Url,
                ShortLink = GenerateShortUrl(6),
                NoOfClicks = 0,
                UserId = loggedInUserId,
                DateCreated = DateTime.Now
            };

            _context.Urls.Add(newUrl);
            _context.SaveChanges();

            TempData["Message"] = $"Your url was shorted to {newUrl.ShortLink}";
            return RedirectToAction("Index");
        }

        private string GenerateShortUrl(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
