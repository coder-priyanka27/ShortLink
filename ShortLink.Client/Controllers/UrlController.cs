using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortLink.Client.Data.ViewModels;
using ShortLink.Data;
using ShortLink.Data.Models;
using ShortLink.Data.Services;

namespace ShortLink.Client.Controllers
{
    public class UrlController : Controller
    {
        private IUrlsService _urlsService;
        private readonly IMapper _mapper;
        public UrlController(IUrlsService urlsService, IMapper mapper)
        {
            _urlsService = urlsService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            //// Data is from DB

            var allUrls = _urlsService.GetUrls();
            var mappedAllUrls = _mapper.Map<List<Url>, List<GetUrlViewModel>>(allUrls);
            return View(mappedAllUrls);
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
            _urlsService.Delete(id);
            return RedirectToAction("Index");
        }
        

    }
}
