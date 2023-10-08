using Asp_Net_Core_ETicaret.Areas.AdminOperations.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Data;
using X.PagedList;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminOperations")]
    public class UserAdminController : Controller
    {
        UserAdminManager um = new UserAdminManager(new EfUserAdminRepository());
        private readonly Context _context;
        private readonly IConfiguration _configuration;

        public UserAdminController(Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult UserAdminList(int page = 1)
        {
            var Values = um.GetListAllUser().ToPagedList(page, 6);
            return View(Values);
        }

        [HttpGet]
        public IActionResult UserAdminDelete(Guid ID)
        {
            var Values = um.TGetByGUID(ID);
            um.TDelete(Values);
            return RedirectToAction(nameof(UserAdminList));
        }


        [HttpGet]
        public IActionResult UserAdminEdit(Guid ID)
        {
            UserAdminTable userAdminTable = _context.UserAdminTables.Find(ID);
            return View(userAdminTable);
        }
        [HttpPost]
        public IActionResult UserAdminEdit(UserAdminTable p)
        {
            um.TUpdate(p);
            return RedirectToAction(nameof(UserAdminList));
        }



        [HttpGet]
        public IActionResult UserAdminAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserAdminAdd(AddViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_context.UserAdminTables.Any(x => x.NameSurname.ToLower() == model.NameSurname.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.NameSurname), "Bu İsim Kayıtlı Lütfen Farklı Bir İsim Giriniz");
                    return View(model);

                }
                else
                {
                    string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
                    string saltPassword = model.Password + md5Salt;
                    string hashedPassword = saltPassword.MD5();
                    if (ModelState.IsValid)
                    {
                        UserAdminTable userAdminTable = new()
                        {
                            NameSurname = model.NameSurname,
                            Password = hashedPassword
                        };
                        _context.UserAdminTables.Add(userAdminTable);
                        int AffectedRowCount = _context.SaveChanges();
                        if (AffectedRowCount == 0)
                        {
                            ModelState.AddModelError("", "Kullanıcı Giriş Yapmadı!!!");
                        }
                        else
                        {
                            return RedirectToAction("UserAdminList", "UserAdmin");
                        }
                    }
                }
            }
            return View(model);
        }
    }
}
