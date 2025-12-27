using Microsoft.AspNetCore.Mvc;
using ShortLink.Client.Data.Models;

namespace ShortLink.Client.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index()
        {
            //// Data is from DB
            //var urlDb = new Url()
            //{
            //    Id = 1,
            //    OriginalLink = "https://original.com",
            //    ShortLink = "Shortlink",
            //    NoOfClicks = 1,
            //    UserId = 1,
            //};

            //var allData = new List<Url>();
            //allData.Add(urlDb);
            //ViewData["ShortenedUrl"] = "This is just a short url";
            //ViewData["AllUrls"] = new List<string>() { "Url 1", "Url 2", "Url 3" };
            //ViewBag.ShortenedUrl = "This is just a short url";
            //ViewBag.AllUrls = new List<string>() { "Url 1", "Url 2", "Url 3", "Url 4" };
            var tempData = TempData["Successmessage"];
            var viewBag = ViewBag.Test1;
            var viewData = ViewData["Test2"];
            if (TempData["Successmessage"] != null)
            {
               if(TempData["Successmessage"] != null)
                {
                    ViewBag.Successmessage = TempData["Successmessage"].ToString();
                }
            }
            return View();
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
