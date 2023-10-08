using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_ETicaret.ViewComponents.Admin
{
    public class AdminStatistics2:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            ViewBag.V1 = c.OrderTables.Count().ToString();

            ViewBag.V2 = c.ProductTables.Count().ToString();

            ViewBag.V3 = c.UserAdminTables.Count().ToString();

            ViewBag.V4 = c.CategoryTables.Count().ToString();

            ViewBag.V5 = c.CommentTables.Count().ToString();

            ViewBag.V6 = c.MessageTables.Count().ToString();

            ViewBag.V7 = c.CargoTables.Count().ToString();

            ViewBag.V8 = c.BestSellersTables.Count().ToString();

            return View();
        }
    }
}
