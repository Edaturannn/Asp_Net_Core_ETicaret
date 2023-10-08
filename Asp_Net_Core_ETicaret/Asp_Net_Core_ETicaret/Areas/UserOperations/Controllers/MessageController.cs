using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using X.PagedList;

namespace Asp_Net_Core_ETicaret.Areas.UserOperations.Controllers
{
    [Authorize(Roles = "user")]
    [Area("UserOperations")]
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());

        [HttpGet]
        public IActionResult MessageList(int page = 1)
        {
            var Values = mm.GetListAllMessage().ToPagedList(page, 4);
            return View(Values);
        }
    }
}
