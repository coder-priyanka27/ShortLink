using Microsoft.AspNetCore.Mvc;
using ShortLink.Client.Data.ViewModels;
using ShortLink.Data;

namespace ShortLink.Client.Controllers
{
    public class UrlController : Controller
    {
        private AppDbContext _context { get; set; }
        public UrlController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //// Data is from DB

            var allUrls = _context.Urls.Select(url => new GetUrlViewModel()
            {
                Id = url.Id,
                OriginalLink = url.OriginalLink,
                ShortLink = url.ShortLink,
                NoOfClicks = url.NoOfClicks,
                UserId = url.UserId
            }).ToList();
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

        public IActionResult Remove(int id)
        {
            var url = _context.Urls.FirstOrDefault(n => n.Id == id);
            _context.Urls.Remove(url);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        

    }
}
