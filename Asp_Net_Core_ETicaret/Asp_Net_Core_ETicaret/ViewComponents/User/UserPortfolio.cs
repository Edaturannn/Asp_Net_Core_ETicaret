using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Asp_Net_Core_ETicaret.ViewComponents.User
{
    public class UserPortfolio:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //İSTANBUL İÇİN HAVA DURUMU XML FORMATINDA API İLE ALMA...
            string api = "4a3f55df8d9e54fcf0ac948c61e3c643";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.V1 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
            //İSTANBUL İÇİN HAVA DURUMU XML FORMATINDA API İLE ALMA...
        }
    }
}
