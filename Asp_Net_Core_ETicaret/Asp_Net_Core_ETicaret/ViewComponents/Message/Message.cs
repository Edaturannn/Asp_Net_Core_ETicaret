using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_ETicaret.ViewComponents.Message
{
    public class Message:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            ViewBag.V1 = c.MessageTables.Count().ToString();
            ViewBag.V2 = c.UserAdminTables.Count().ToString();
            return View();
        }
    }
}
