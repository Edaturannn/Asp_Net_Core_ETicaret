using Asp_Net_Core_ETicaret.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Asp_Net_Core_ETicaret.Controllers
{
	public class RegisterController : Controller
	{
		private readonly Context _context;
		private readonly IConfiguration _configuration;

		public RegisterController(Context context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(RegisterViewModel model)
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
							return RedirectToAction("Index", "Login");
						}
					}
				}
			}
			return View(model);
		}
	}
}
