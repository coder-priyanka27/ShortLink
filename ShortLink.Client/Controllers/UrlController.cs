using Microsoft.AspNetCore.Mvc;
using ShortLink.Client.Data.Models;

namespace ShortLink.Client.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index()
        {
            //// Data is from DB
            var allUrls = new List<Url>()
            {
                new Url
                {
                    Id = 1,
                    OriginalLink = "https://example1.com/1",
                    ShortLink = "https://shortlink1/1",
                    NoOfClicks = 1,
                    UserId = 1
                },

                new Url
                {
                    Id = 2,
                    OriginalLink = "https://example2.com/2",
                    ShortLink = "https://shortlink2/2",
                    NoOfClicks = 2,
                    UserId = 2
                },
                new Url
                {
                    Id = 3,
                    OriginalLink = "https://example3.com/3",
                    ShortLink = "https://shortlink3/3",
                    NoOfClicks = 3,
                    UserId = 3
                },            };
            return View(allUrls);
        }

        public IActionResult Create()
        {
            //Shorten Url
            var shortenUrl = "Short";
            TempData["Successmessage"] = "Sucessful!";
            ViewBag.Test1 = "Test1";
            ViewData["Test2"] = "Test2";

            return RedirectToAction("Index");
        }
    }
}
