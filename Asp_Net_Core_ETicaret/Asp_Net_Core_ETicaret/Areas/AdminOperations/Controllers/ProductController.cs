using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Data;
using X.PagedList;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Controllers
{
	[Authorize(Roles = "admin")]
	[Area("AdminOperations")]
	public class ProductController : Controller
	{
        private readonly Context _context;

        ProductManager pm = new ProductManager(new EfProductRepository());
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public ProductController(Context context)
        {
            _context = context;
        }

        [HttpGet]
		public IActionResult ProductList(int page = 1)
		{
			var Values = pm.GetListCategory().ToPagedList(page, 4);
            return View(Values);
        }

		[HttpGet]
		public IActionResult ProductDelete(int id)
		{
			var Values = pm.TGetByID(id);
			pm.TDelete(Values);
			return RedirectToAction(nameof(ProductList));
		}

		[HttpGet]
		public IActionResult ProductAdd()
        {
            List<SelectListItem> CategoryValues = (from x in cm.GetListAllCategory()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID.ToString()
                                                 }).ToList();
            ViewBag.cv = CategoryValues;
            return View();
        }
		[HttpPost]
		public IActionResult ProductAdd(ProductTable p, [Required] IFormFile productfile)
		{
            string productfileName = $"product_{p.ProductName}.jpg";
            Stream stream = new FileStream($"wwwroot/ProductImg/{productfileName}", FileMode.OpenOrCreate);

            productfile.CopyTo(stream);

            stream.Close();
            stream.Dispose();

            p.ProductImages = productfileName;
            _context.SaveChanges();


            pm.TAdd(p);
			return RedirectToAction(nameof(ProductList));
		}

		[HttpGet]
		public IActionResult ProductEdit(int id)
		{
            List<SelectListItem> CategoryValues = (from x in cm.GetListAllCategory()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = CategoryValues;


            var Values = pm.TGetByID(id);
			return View(Values);
		}

		[HttpPost]
		public IActionResult ProductEdit(ProductTable p)
		{
			pm.TUpdate(p);
			return RedirectToAction(nameof(ProductList));
		}
    }
}
