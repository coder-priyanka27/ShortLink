using Microsoft.AspNetCore.Mvc;

namespace ShortLink.Client.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
