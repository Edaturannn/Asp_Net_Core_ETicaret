using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Asp_Net_Core_ETicaret.Areas.UserOperations.Controllers
{
	[Authorize(Roles = "user")]
	[Area("UserOperations")]
	public class ProductController : Controller
	{
		ProductManager pm = new ProductManager(new EfProductRepository());
		public IActionResult ProductListByCategoryID(int id)
		{
			var Values = pm.GetListByCategoryID(id);
			return View(Values);
		}

		public IActionResult SelectListByProduct(int id)
		{
			var Values = pm.GetListProductID(id);
			return View(Values);
		}
	}
}
