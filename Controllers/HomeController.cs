using BrickedUpBrickBuyer.Data;
using BrickedUpBrickBuyer.Data.ViewModels;

using BrickedUpBrickBuyer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

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
        public IActionResult Products(string primaryColor, string category)
        {
            var productInfos = new ProductsPagesViewModel
            {
                Products = _brickRepository.Products
                .Where(x => (primaryColor ==null || x.PrimaryColor == primaryColor || x.SecondaryColor == primaryColor) && (x.Category == category || category ==null))

                .OrderBy(x => x.Name),
                CurrentColor = primaryColor,
                CurrentCategory = category,
            }; 
            return View(productInfos);
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
