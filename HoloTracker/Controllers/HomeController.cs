using HoloTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HoloTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHololiveApiService _hololiveApiService;

        public HomeController(IHololiveApiService hololiveApiService)
        {
            _hololiveApiService = hololiveApiService;
        }

        public async Task<IActionResult> Index(string value)
        {
            AllHololiveModel talents = new AllHololiveModel();
            List<HololiveModel> empty = new List<HololiveModel>();
            talents = await _hololiveApiService.GetLive();

            if (value == "live") { return View(talents.live); }
            else if (value == "upcoming") { return View(talents.upcoming); }
            else if (value == "ended") { return View(talents.ended); }

            return View(empty);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}