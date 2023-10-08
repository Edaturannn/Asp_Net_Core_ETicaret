using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_ETicaret.ViewComponents.User
{
    public class UserIframe:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
