using Asp_Net_Core_ETicaret.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using System.Security.Claims;

namespace Asp_Net_Core_ETicaret.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        public LoginController(Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
            string saltPassword = model.Password + md5Salt;
            string hashedPassword = saltPassword.MD5();

            if (ModelState.IsValid)
            {
                UserAdminTable userAdminTable = _context.UserAdminTables.SingleOrDefault(x => x.NameSurname.ToLower() == model.NameSurname.ToLower() && x.Password == hashedPassword);
                if (userAdminTable != null)
                {
                    if (userAdminTable.Locked == false)
                    {
                        ModelState.AddModelError(nameof(model.NameSurname), "Kullanıcı Pasif Lütfen Farklı Bir İsim Giriniz!!!");
                        return View(model);
                    }
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, userAdminTable.ID.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, userAdminTable.NameSurname.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, userAdminTable.NameSurname ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, userAdminTable.Role));
                    claims.Add(new Claim("NameSurname", userAdminTable.NameSurname));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    if (userAdminTable.Role == "user")
                    {
                        return RedirectToAction("User", "User");
                    }
                    else if (userAdminTable.Role == "admin")
                    {
                        return RedirectToAction("Admin", "Admin");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı Veya Şifre Hatalı Lütfen Tekradan Deneyiniz!!!");
                }
            }
            return View(model);
        }
    }
}
