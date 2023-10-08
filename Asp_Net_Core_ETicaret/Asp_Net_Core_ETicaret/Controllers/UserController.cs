using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_ETicaret.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult User()
        {
            Context c = new Context();
            ViewBag.V1 = c.MessageTables.Count().ToString();

            return View();
        }
    }
}
