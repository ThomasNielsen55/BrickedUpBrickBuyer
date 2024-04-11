using BrickedUpBrickBuyer.Data;
using BrickedUpBrickBuyer.Data.ViewModels;

//using BrickedUpBrickBuyer.Models;
//using BrickedUpBrickBuyer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

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
			var Bricks = _brickRepository.Customers.ToList();

			return View(Bricks);
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
            //var products = _brickRepository.Products;
            //var ViewModel= new FilterViewModel

            //{
            //    Categories = _brickRepository.Products
            // .Select(x => x.Category ?? "")
            // .Where(x => !string.IsNullOrWhiteSpace(x))
            // .Distinct()
            // .OrderBy(x => x)
            //};

            //var modifiedCategories = ViewModel.Categories.Select(m => m.Split(" - ").FirstOrDefault()).ToList();

            //ViewModel.Categories = modifiedCategories;
            
            var productInfos = new ProductsPagesViewModel
            {
                Products = _brickRepository.Products
                .Where(x => (primaryColor ==null || x.PrimaryColor == primaryColor || x.SecondaryColor == primaryColor) && (x.Category.Contains(category) || category ==null))
                .OrderBy(x => x.Name),
                CurrentColor = primaryColor,
                CurrentCategory = category,
            }; 
            return View(productInfos);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Confirmation()
        {
            return View();
        }
        public IActionResult Review()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SelectedProduct(int Productnumba = 1)
        {
            var Productguy = new Product();
            Productguy = _brickRepository.Products.ToList()
                .Where(x => x.ProductId == Productnumba)
                .FirstOrDefault();

            return View(Productguy);
        }

        public IActionResult ReviewOrders()
        {
            var records = _repo.Orders
                .OrderByDescending(x => x.Date)
                .Take(20)
                .ToList(); // Fetch the 20 most recent orders
            var predictions = new List<OrderPrediction>(); // Your viewmodel here :)

            var class_type_dict = new Dictionary<int, string>
                {
                    { 0, "Not Fraud"},
                    { 1, "Fraud"}
                };

            foreach (var record in records) 
            {
                var input = new List<float>
                {
                    (float)record.time,
                    (float)(record.amount ?? 0),

                    // Check the dummy code (country of residence is on a different table than gender and everything else... idk)
                    record.country_of_residence == "India" ? 1 : 0,
                    record.country_of_residence == "Russia" ? 1 : 0,
                    record.country_of_residence == "USA" ? 1 : 0,
                    record.country_of_residence == "UnitedKingdom" ? 1 : 0, //IDK IF THIS UnitedKingdom is the right format or if it should be United_Kingdom

                    record.gender
                }
            }

            return View(predictions);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
