using gh_signalr_demo.Models;
using gh_signalr_demo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace gh_signalr_demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFarmTempRepo _FarmRepo;

        public HomeController(IFarmTempRepo auctionRepo)
        {
            _FarmRepo = auctionRepo;
        }

        public IActionResult Index()
        {
            var auctions = _FarmRepo.GetAll();
            return View(auctions);
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