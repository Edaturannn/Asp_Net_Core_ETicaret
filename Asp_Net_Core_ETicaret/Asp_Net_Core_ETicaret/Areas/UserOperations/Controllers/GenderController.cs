using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Asp_Net_Core_ETicaret.Areas.UserOperations.Controllers
{
    [Authorize(Roles = "user")]
    [Area("UserOperations")]
    public class GenderController : Controller
    {
        GenderManager gm = new GenderManager(new EfGenderRepository());
        [HttpGet]
        public IActionResult GenderList()
        {
            var Values = gm.GetListAllGender();
            return View(Values);
        }
    }
}
