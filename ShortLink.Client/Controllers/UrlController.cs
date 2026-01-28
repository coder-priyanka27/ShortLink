using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortLink.Client.Data.ViewModels;
using ShortLink.Client.Helpers.Roles;
using ShortLink.Data;
using ShortLink.Data.Models;
using ShortLink.Data.Services;
using System.Security.Claims;

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
        public async Task<IActionResult> Index()
        {
            var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole(Role.Admin);

            var allUrls = await _urlsService.GetUrlsAsync(loggedInUserId, isAdmin);
            var mappedAllUrls = _mapper.Map<List<Url>, List<GetUrlViewModel>>(allUrls);
            return View(mappedAllUrls);
        }

        public async Task<IActionResult> Create()
        {
            //Shorten Url
            var shortenUrl = "Short";
            TempData["Successmessage"] = "Sucessful!";
            ViewBag.Test1 = "Test1";
            ViewData["Test2"] = "Test2";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _urlsService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        

    }
}
