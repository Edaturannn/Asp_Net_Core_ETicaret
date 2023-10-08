using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Claims;
using X.PagedList;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminOperations")]
    public class CategoryController : Controller
    {
        private readonly Context _context;

        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        GenderManager gm = new GenderManager(new EfGenderRepository());
        public CategoryController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CategoryList(int page = 1)
        {
            var Values = cm.GetListAllCategory().ToPagedList(page, 4);
            return View(Values);
        }

        [HttpGet]
        public IActionResult CategoryDelete(int id)
        {
            var Values = cm.TGetByID(id);
            cm.TDelete(Values);
            return RedirectToAction("CategoryList", "Category");
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            List<SelectListItem> GenderValues = (from x in gm.GetListAllGender()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Gender,
                                                     Value = x.GenderID.ToString()
                                                 }).ToList();
            ViewBag.gv = GenderValues;
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(CategoryTable p, [Required] IFormFile file)
        {
            string fileName = $"category_{p.CategoryName}.jpg";
            Stream stream = new FileStream($"wwwroot/CategoryImg/{fileName}", FileMode.OpenOrCreate);

            file.CopyTo(stream);

            stream.Close();
            stream.Dispose();

            p.CategoryImages = fileName;
            _context.SaveChanges();
            cm.TAdd(p);
            return RedirectToAction("CategoryList", "Category");
        }

        [HttpGet]
        public IActionResult CategoryEdit(int id)
        {
            List<SelectListItem> GenderValues = (from x in gm.GetListAllGender()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Gender,
                                                     Value = x.GenderID.ToString()
                                                 }).ToList();
            ViewBag.gv = GenderValues;





            var Values = cm.TGetByID(id);
            return View(Values);
        }
        [HttpPost]
        public IActionResult CategoryEdit(CategoryTable p)
        { 
            cm.TUpdate(p);
            return RedirectToAction("CategoryList", "Category");
        }
    }
}
