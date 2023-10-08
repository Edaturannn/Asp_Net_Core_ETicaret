using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminOperations")]
    public class CargoController : Controller
    {
        CargoManager cm = new CargoManager(new EfCargoRepository());

        [HttpGet]
        public IActionResult CargoList(int page = 1)
        {
            var Values = cm.GetListCargo().ToPagedList(page, 4);
            return View(Values);
        }


        [HttpGet]
        public IActionResult CargoAdd(int id)
        {
            ViewBag.V1 = id;
            return View();
        }

        [HttpPost]
        public IActionResult CargoAdd(CargoTable p, int id)
        {
            p.OrderID = ViewBag.V1 = id;
            cm.TAdd(p);
            return RedirectToAction("CargoList", "Cargo");
        }

        [HttpGet]
        public IActionResult CargoDelete(int id)
        {
            var Values = cm.TGetByID(id);
            cm.TDelete(Values);
            return RedirectToAction("CargoList", "Cargo");
        }
    }
}
