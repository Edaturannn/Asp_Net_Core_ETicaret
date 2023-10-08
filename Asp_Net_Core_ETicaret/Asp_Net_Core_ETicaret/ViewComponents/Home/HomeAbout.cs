using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_ETicaret.ViewComponents.Home
{
    public class HomeAbout:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            {
                return View();
            }
        }
    }
}
