using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DataAccessLayer.Concrete;

namespace Asp_Net_Core_ETicaret.Controllers
{
    [Authorize]
    public class LogoutController : Controller
    {
        private readonly Context _context;
        public LogoutController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Logout");
        }
    }
}
