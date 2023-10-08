using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_ETicaret.Areas.MyProfileOperations.Controllers
{
	[Area("MyProfileOperations")]
	public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
