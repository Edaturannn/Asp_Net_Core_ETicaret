using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using X.PagedList;

namespace Asp_Net_Core_ETicaret.Areas.UserOperations.Controllers
{
    [Authorize(Roles = "user")]
    [Area("UserOperations")]
    public class OrderController : Controller
    {
        private readonly Context _context;
        OrderManager om = new OrderManager(new EfOrderRepository());



        public OrderController(Context context)
        {
            _context = context;
        }

        public IActionResult MyOrderList(int page = 1)
        {
            Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            UserAdminTable userAdminTable = _context.UserAdminTables.SingleOrDefault(x => x.ID == userid);

            var Values = om.GetListUserAdminGuid(userid).ToPagedList(page, 4); 



            return View(Values);
        }
    }
}
