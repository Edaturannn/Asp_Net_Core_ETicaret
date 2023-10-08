using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Security.Claims;
using X.PagedList;

namespace Asp_Net_Core_ETicaret.Areas.UserOperations.Controllers
{
    [Authorize(Roles = "user")]
    [Area("UserOperations")]
    public class CommentController : Controller
    {
        private readonly Context _context;
        CommentManager cm = new CommentManager(new EfCommentRepository());
        UserAdminManager um = new UserAdminManager(new EfUserAdminRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());


        public CommentController(Context context)
        {
            _context = context;
        }
        public IActionResult CommentList(int id, int page = 1)
        {
            var Values = cm.GetListByProductID(id).ToPagedList(page, 4);
            return View(Values);
        }
        [HttpGet]
        public IActionResult CommentLeave(int id)
        {
            ViewBag.V1 = id;
            return View();
        }
        [HttpPost]
        public IActionResult CommentLeave(CommentTable p,int id)
        {
            Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            UserAdminTable userAdminTable = _context.UserAdminTables.SingleOrDefault(x => x.ID == userid);
            p.ID = userid;
            p.ProductID = ViewBag.V1 = id;
            cm.TAdd(p);
            return RedirectToAction("Comment", "Comment");

        }

        public IActionResult Comment()
        {
            return View();
        }
    }
}
