using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.EMMA;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using X.PagedList;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminOperations")]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        UserAdminManager um = new UserAdminManager(new EfUserAdminRepository());

        [HttpGet]
        public IActionResult CommentList(int page = 1)
        {
            var Values = cm.GetListProduct().ToPagedList(page, 2);
            return View(Values);
        }

        [HttpGet]
        public IActionResult CommentDelete(int id)
        {
            var Values = cm.TGetByID(id);
            cm.TDelete(Values);
            return RedirectToAction("CommentList", "Comment");
        }

        [HttpGet]
        public IActionResult CommentEdit(int id)
        {
            var Values = cm.TGetByID(id);
            List<SelectListItem> UserAdminValues = (from x in um.GetListAllUser()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.NameSurname,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.uv = UserAdminValues;


            List<SelectListItem> ProductValues = (from x in pm.GetListAllProduct()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.ProductName,
                                                      Value = x.ProductID.ToString()
                                                  }).ToList();
            ViewBag.pv = ProductValues;
            return View(Values);
        }
        [HttpPost]
        public IActionResult CommentEdit(CommentTable p)
        {
            cm.TUpdate(p);
            return RedirectToAction("CommentList", "Comment");
        }
    }
}
