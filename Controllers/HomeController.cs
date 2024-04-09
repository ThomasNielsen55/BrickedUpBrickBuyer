using BrickedUpBrickBuyer.Data;
using BrickedUpBrickBuyer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BrickedUpBrickBuyer.Controllers
{
    public class HomeController : Controller
    {
		private IBrickRepository _brickRepository;
		public HomeController(IBrickRepository brick)
		{
			_brickRepository = brick;
		}

		public IActionResult Index()
        {
			var Bricks = _brickRepository.Orders.ToList();


			return View(Bricks);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult AccountCreate()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SelectedProduct()
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
