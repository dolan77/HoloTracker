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

        public async Task<IActionResult> Index(string value, string org)
        {
            List<HololiveModel> talents = new List<HololiveModel>();
            AllHololiveModel? temp;

            // save an api call if there is no input
            if (value == null && org == null)
            {
                temp = null;
                return View(temp);
            }


            talents = await _hololiveApiService.GetLive(org); // this is a list of HololiveModels async






            // we want either live or not live
            if (org == null) { org = "Everyone"; }

            if (value != null)
            {
                if (value == "live")
                {
                    temp = new AllHololiveModel()
                    {
                        streamers = talents.Where(streamer => streamer.status == "live").ToList(),
                        state = "live",
                        organization = org
                        
                    };
                    return View(temp);
                }

                else if (value == "upcoming")
                {
                    temp = new AllHololiveModel()
                    {
                        streamers = talents.Where(streamer => streamer.status == "upcoming").ToList(),
                        state = "upcoming",
                        organization = org
                    };
                    return View(temp);
                }
            }

            // we want both live and upcoming from a specific org
            temp = new AllHololiveModel()
            {
                streamers = talents,
                state = "Live and Upcoming",
                organization= org
            };


            return View(temp);
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