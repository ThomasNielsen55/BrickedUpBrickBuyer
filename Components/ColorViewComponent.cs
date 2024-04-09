using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BrickedUpBrickBuyer.Data;
using Microsoft.AspNetCore.Mvc;
using BrickedUpBrickBuyer.Data.ViewModels;

namespace BrickedUpBrickBuyer.Components
{
	public class ColorViewComponent : ViewComponent
	{
		private IBrickRepository _brickRepo;
		public ColorViewComponent(IBrickRepository temp)
		{
			_brickRepo = temp;
		}
		public IViewComponentResult Invoke()
		{
            ViewBag.SelectedPrimaryColor = RouteData?.Values["PrimaryColor"];
            ViewBag.SelectedCategory = RouteData?.Values["Category"];

            var viewModel = new FilterViewModel
            {
                Categories = _brickRepo.Products
         .Select(x => x.Category ?? "")
         .Where(x => !string.IsNullOrWhiteSpace(x))
         .Distinct()
         .OrderBy(x => x),

                PrimaryColors = _brickRepo.Products
         .Select(x => x.PrimaryColor ?? "")
         .Where(x => !string.IsNullOrWhiteSpace(x))
         .Distinct()
         .OrderBy(x => x)
            };




            return View(viewModel);
        }




	}
}
