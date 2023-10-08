using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_ETicaret.ViewComponents.Home
{
    public class HomeProject:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
