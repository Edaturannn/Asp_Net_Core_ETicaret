using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Claims;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminOperations")]
    public class MyProfileController : Controller
    {
        private readonly Context _context;
        UserAdminManager um = new UserAdminManager(new EfUserAdminRepository());
        public MyProfileController(Context context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            UserAdminTable userAdminTable = _context.UserAdminTables.SingleOrDefault(x => x.ID == userid);


            return View(userAdminTable);
        }
        [HttpPost]
        public IActionResult Index(UserAdminTable p)
        {
            um.TUpdate(p);
            return RedirectToAction("Index", "MyProfile");
        }
    }
}
