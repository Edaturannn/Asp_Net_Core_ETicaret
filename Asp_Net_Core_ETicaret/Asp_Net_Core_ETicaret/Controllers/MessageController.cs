using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Asp_Net_Core_ETicaret.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());

        [HttpGet]
        public PartialViewResult MessageAddPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult MessageAddPartial(MessageTable p)
        {
            mm.TAdd(p);
            Response.Redirect("/UserOperations/Message/MessageList/" + 1);
            return PartialView();
        }


        [HttpGet]
        public IActionResult MessageList(int page = 1)
        {
            var Values = mm.GetListAllMessage().ToPagedList(page, 5);
            return View(Values);
        }

        [HttpGet]
        public IActionResult MessageDelete(int id)
        {
            var Values = mm.TGetByID(id);
            mm.TDelete(Values);
            return RedirectToAction("MessageList", "Message");
        }

        [HttpGet]
        public IActionResult MessageEdit(int id)
        {
            var Values = mm.TGetByID(id);
            return View(Values);
        }
        [HttpPost]
        public IActionResult MessageEdit(MessageTable p)
        {
            MessageValidator mv = new MessageValidator();
            ValidationResult result = mv.Validate(p);

            if (result.IsValid)
            {
                mm.TUpdate(p);
                return RedirectToAction("MessageList", "Message");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            
        }

        public IActionResult MessageDetails(int id)
        {
            var Values = mm.TGetByID(id);
            return View(Values);
        }
    }
}
