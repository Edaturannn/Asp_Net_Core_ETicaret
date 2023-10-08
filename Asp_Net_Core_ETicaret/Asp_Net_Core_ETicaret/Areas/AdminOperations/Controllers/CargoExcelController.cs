using Asp_Net_Core_ETicaret.Areas.AdminOperations.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminOperations")]
    public class CargoExcelController : Controller
    {
        public IActionResult CargoExcelCreate()
        {
            using (var WorkBook = new XLWorkbook())
            {
                var WorkSheet = WorkBook.Worksheets.Add("Cargo List");

                WorkSheet.Cell(1, 1).Value = "Cargo Name";
                WorkSheet.Cell(1, 2).Value = "Cargo Create Date";
                WorkSheet.Cell(1, 3).Value = "Order ID";

                WorkSheet.Cell(1, 4).Value = "City";
                WorkSheet.Cell(1, 5).Value = "Country";

                WorkSheet.Cell(1, 6).Value = "Name Surname";

                WorkSheet.Cell(1, 7).Value = "Phone Number";

                int CargoRowCount = 7;
                foreach (var item in CargoTitleList())
                {
                    WorkSheet.Cell(CargoRowCount, 1).Value = item.CargoName;

                    WorkSheet.Cell(CargoRowCount, 2).Value = item.CargoCreateDate;

                    WorkSheet.Cell(CargoRowCount, 3).Value = item.OrderID;

                    WorkSheet.Cell(CargoRowCount, 4).Value = item.City;

                    WorkSheet.Cell(CargoRowCount, 5).Value = item.Country;

                    WorkSheet.Cell(CargoRowCount, 6).Value = item.NameSurname;

                    WorkSheet.Cell(CargoRowCount, 7).Value = item.PhoneNumber;


                    CargoRowCount++;
                }
                using (var Stream = new MemoryStream())
                {
                    WorkBook.SaveAs(Stream);
                    var Content = Stream.ToArray();
                    return File(Content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "cargolist.xlsx");
                }
            }
        }


        public List<CargoModel> CargoTitleList()
        {
            List<CargoModel> cm = new List<CargoModel>();
            {
                using (var c = new Context())
                {
                    cm = c.CargoTables.Select(x => new CargoModel
                    {
                        CargoName = x.CargoName,
                        CargoCreateDate = x.CargoCreateDate,

                        OrderID = x.OrderID,
                        City = x.City,

                        Country = x.Country,
                        NameSurname = x.NameSurname,

                        PhoneNumber = x.PhoneNumber

                    }).ToList();
                }
            }
            return cm;
        }
    }
}
