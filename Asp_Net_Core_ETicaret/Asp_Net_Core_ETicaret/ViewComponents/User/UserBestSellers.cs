using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_ETicaret.ViewComponents.User
{
    public class UserBestSellers:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BestSellersManager bsm = new BestSellersManager(new EfBestSellersRepository());
            var Values = bsm.GetListAllBestSellers();
            return View(Values);
        }
    }
}
