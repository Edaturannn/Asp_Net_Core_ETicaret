using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using X.PagedList;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminOperations")]
    public class OrderController : Controller
    {
        OrderManager om = new OrderManager(new EfOrderRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());

        [HttpGet]
        public IActionResult OrderAllList(int page = 1)
        {
            var Values = om.GetListProduct().ToPagedList(page, 4);
            return View(Values);
        }

        [HttpGet]
        public IActionResult OrderAllDelete(int id)
        {
            var Values = om.TGetByID(id);
            om.TDelete(Values);
            return RedirectToAction("OrderAllList", "Order");
        }

        [HttpGet]
        public IActionResult List(int id)
        {
            var Values = om.GetListOrderID(id);
            return View(Values);
        }
    }
}
