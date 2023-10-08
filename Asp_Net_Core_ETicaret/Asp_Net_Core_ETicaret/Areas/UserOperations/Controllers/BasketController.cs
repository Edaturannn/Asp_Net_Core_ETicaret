using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Asp_Net_Core_ETicaret.Areas.UserOperations.Controllers
{
    [Authorize(Roles = "user")]
    [Area("UserOperations")]
    public class BasketController : Controller
    {
        private readonly Context _context;
        ProductManager pm = new ProductManager(new EfProductRepository());
        OrderManager om = new OrderManager(new EfOrderRepository());
        Context c = new Context();



        public BasketController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult BasketList(int id)
        {
            var Values = pm.GetListProductID(id);
            return View(Values);
        }

        [HttpGet]
        public IActionResult BasketAdd(int id)
        {
            ViewBag.v1 = id;
            return View();
        }

        [HttpPost]
        public IActionResult BasketAdd(OrderTable p, int id)
        {
            Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            UserAdminTable userAdminTable = _context.UserAdminTables.SingleOrDefault(x => x.ID == userid);
            p.ID = userid;

            p.ProductID = ViewBag.v1 = id;
            om.TAdd(p);
            return RedirectToAction("Order", "Basket");
        }


        [HttpGet]
        public IActionResult Order()
        {
            return View();
        }
    }
}
