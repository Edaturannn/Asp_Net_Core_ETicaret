using Asp_Net_Core_ETicaret.Areas.AdminOperations.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminOperations")]
    public class ProductExcelController : Controller
    {
        public IActionResult ProductExcelCreate()
        {
            using (var WorkBook = new XLWorkbook())
            {
                var WorkSheet = WorkBook.Worksheets.Add("Product List");

                WorkSheet.Cell(1, 1).Value = "Product Name";
                WorkSheet.Cell(1, 2).Value = "Product Title";
                WorkSheet.Cell(1, 3).Value = "Product Description";

                WorkSheet.Cell(1, 4).Value = "Product Images";
                WorkSheet.Cell(1, 5).Value = "Product Price";

                WorkSheet.Cell(1, 6).Value = "Product Stok";
                WorkSheet.Cell(1, 7).Value = "Product Create Date";
                WorkSheet.Cell(1, 8).Value = "Category ID";

                int ProductRowCount = 8;
                foreach (var item in ProductTitleList())
                {
                    WorkSheet.Cell(ProductRowCount, 1).Value = item.ProductName;

                    WorkSheet.Cell(ProductRowCount, 1).Value = item.ProductTitle;

                    WorkSheet.Cell(ProductRowCount, 1).Value = item.ProductDescription;

                    WorkSheet.Cell(ProductRowCount, 1).Value = item.ProductImages;

                    WorkSheet.Cell(ProductRowCount, 1).Value = item.ProductPrice;

                    WorkSheet.Cell(ProductRowCount, 1).Value = item.ProductStok;

                    WorkSheet.Cell(ProductRowCount, 1).Value = item.ProductCreateDate;

                    WorkSheet.Cell(ProductRowCount, 1).Value = item.CategoryID;

                    ProductRowCount++;
                }
                using (var Stream = new MemoryStream())
                {
                    WorkBook.SaveAs(Stream);
                    var Content = Stream.ToArray();
                    return File(Content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "productlist.xlsx");
                }
            }
        }

        public List<ProductModel> ProductTitleList()
        {
            List<ProductModel> pm = new List<ProductModel>();
            {
                using (var c = new Context())
                {
                    pm = c.ProductTables.Select(x => new ProductModel
                    {
                        ProductName = x.ProductName,
                        ProductTitle = x.ProductTitle,
                        ProductDescription = x.ProductDescription,
                        ProductImages = x.ProductImages,
                        ProductPrice = x.ProductPrice,
                        ProductStok = x.ProductStok,
                        ProductCreateDate = x.ProductCreateDate,
                        CategoryID = x.CategoryID

                    }).ToList();
                }
            }
            return pm;
        }
    }
}
