using Microsoft.AspNetCore.Mvc;
using BrickedUpBrickBuyer.Data;
using BrickedUpBrickBuyer.Data.ViewModels;

namespace BrickedUpBrickBuyer.Controllers
{
    public class AdminController : Controller
    {
        private IBrickRepository _brickRepository;
        public AdminController(IBrickRepository brick)
        {
            _brickRepository = brick;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Confirmation()
        {
            return View();
        }
        public IActionResult EditOrder(int orderid)
        {
            var orderdude = new Order();
            orderdude = _brickRepository.Orders.ToList()
                .Where(x => x.TransactionId == orderid)
                .FirstOrDefault();
            return View(orderdude);
        }
        public IActionResult EditProduct(int productid)
        {
            var productdude = new Product();
            productdude = _brickRepository.Products.ToList()
                .Where(x => x.ProductId == productid)
                .FirstOrDefault();
            return View(productdude);
        }
        public IActionResult EditUser(int userid)
        {
            var userdude = new Customer();
            userdude = _brickRepository.Customers.ToList()
                .Where(x => x.customer_ID == userid)
                .FirstOrDefault();
            return View(userdude);
        }
        public IActionResult Orders()
        {
            var ordoos = _brickRepository.Orders.ToList();
            return View(ordoos);
        }
        public IActionResult Products()
        {
            var prodies = _brickRepository.Products.ToList();
            return View(prodies);
        }
        public IActionResult Users()
        {
            var custos = _brickRepository.Customers.ToList();
            return View(custos);
        }
    }
}
