using Asp_Net_Core_ETicaret.Areas.AdminOperations.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminOperations")]
    public class OrderExcelController : Controller
    {
        public IActionResult OrderExcelCreate()
        {
            using (var WorkBook = new XLWorkbook())
            {
                var WorkSheet = WorkBook.Worksheets.Add("Order List");

                WorkSheet.Cell(1, 1).Value = "Order Address";
                WorkSheet.Cell(1, 2).Value = "Product ID";



               

                int OrderRowCount = 2;
                foreach (var item in OrderTitleList())
                {
                  

                    WorkSheet.Cell(OrderRowCount, 1).Value = item.Address;

                    WorkSheet.Cell(OrderRowCount, 2).Value = item.ProductID;

                    


                    OrderRowCount++;
                }
                using (var Stream = new MemoryStream())
                {
                    WorkBook.SaveAs(Stream);
                    var Content = Stream.ToArray();
                    return File(Content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "orderlist.xlsx");
                }
            }
        }

        public List<OrderModel> OrderTitleList()
        {
            List<OrderModel> om = new List<OrderModel>();
            {
                using (var c = new Context())
                {
                    om = c.OrderTables.Select(x => new OrderModel
                    {
                        Address = x.Address,
                        ProductID = x.ProductID

                    }).ToList();
                }
            }
            return om;
        }
    }
}
