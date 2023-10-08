using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminOperations")]
    public class BestSellersController : Controller
    {
        private readonly Context _context;

        BestSellersManager bsm = new BestSellersManager(new EfBestSellersRepository());
        public IActionResult BestSellersList(int page = 1)
        {
            var Values = bsm.GetListAllBestSellers().ToPagedList(page, 4);
            return View(Values);
        }

        public BestSellersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult BestSellersAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BestSellersAdd(BestSellersTable p, [Required] IFormFile file)
        {
            string fileName = $"bestsellers_{p.BestSellersName}.jpg";
            Stream stream = new FileStream($"wwwroot/BestSellersImg/{fileName}", FileMode.OpenOrCreate);

            file.CopyTo(stream);

            stream.Close();
            stream.Dispose();

            p.BestSellersImages = fileName;
            _context.SaveChanges();

            bsm.TAdd(p);
            return RedirectToAction("BestSellersList", "BestSellers");
        }


        [HttpGet]
        public IActionResult BestSellersEdit(int id)
        {
            var Values = bsm.TGetByID(id);
            return View(Values);
        }

        [HttpPost]
        public IActionResult BestSellersEdit(BestSellersTable p)
        {
            bsm.TUpdate(p);
            return RedirectToAction("BestSellersList", "BestSellers");
        }

        public IActionResult BestSellersDelete(int id)
        {
            var Values = bsm.TGetByID(id);
            bsm.TDelete(Values);
            return RedirectToAction("BestSellersList", "BestSellers");
        }
    }
}
