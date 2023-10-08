using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Asp_Net_Core_ETicaret.Areas.UserOperations.Controllers
{
	[Authorize(Roles = "user")]
	[Area("UserOperations")]
	public class CategoryController : Controller
	{
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());
		[HttpGet]
		public IActionResult CategoryListByID(int id)
		{
			var Values = cm.GetListByGenderID(id);
			return View(Values);
		}
	}
}
