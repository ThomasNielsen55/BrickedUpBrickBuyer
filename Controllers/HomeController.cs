using BrickedUpBrickBuyer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BrickedUpBrickBuyer.Controllers
{
    public class HomeController : Controller
    {
        private BrickedUpBrickBuyerContext _context;
        public HomeController(BrickedUpBrickBuyerContext temp)
        {
            _context = temp;
        }

            public IActionResult Index()
        {
            ViewBag.Customer = _context.Customers
               .OrderBy(x => x.customer_ID)
               .ToList();


            return View();
        }
 
    }
}
