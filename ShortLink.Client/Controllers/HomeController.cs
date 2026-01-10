using Microsoft.AspNetCore.Mvc;
using ShortLink.Client.Data.ViewModels;
using System.Diagnostics;

namespace ShortLink.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            //return View("Index");
            return RedirectToAction("Index");
        }

    }
}
