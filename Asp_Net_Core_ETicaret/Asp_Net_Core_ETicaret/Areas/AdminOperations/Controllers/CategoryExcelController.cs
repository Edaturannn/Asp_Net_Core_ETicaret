using Asp_Net_Core_ETicaret.Areas.AdminOperations.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminOperations")]
    public class CategoryExcelController : Controller
    {
        public IActionResult CategoryExcelCreate()
        {
            using (var WorkBook = new XLWorkbook())
            {
                var WorkSheet = WorkBook.Worksheets.Add("Category List");

                WorkSheet.Cell(1, 1).Value = "Category Name";
                WorkSheet.Cell(1, 2).Value = "Category Images";
                WorkSheet.Cell(1, 3).Value = "Category Create Date";

                WorkSheet.Cell(1, 4).Value = "Category Stok";
                WorkSheet.Cell(1, 5).Value = "Gender ID";

                int CategoryRowCount = 5;
                foreach (var item in CategoryTitleList())
                {
                    WorkSheet.Cell(CategoryRowCount, 1).Value = item.CategoryName;

                    WorkSheet.Cell(CategoryRowCount, 2).Value = item.CategoryImages;

                    WorkSheet.Cell(CategoryRowCount, 3).Value = item.CategoryCreateDate;

                    WorkSheet.Cell(CategoryRowCount, 4).Value = item.CategoryStok;

                    WorkSheet.Cell(CategoryRowCount, 5).Value = item.GenderID;


                    CategoryRowCount++;
                }
                using (var Stream = new MemoryStream())
                {
                    WorkBook.SaveAs(Stream);
                    var Content = Stream.ToArray();
                    return File(Content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "categorylist.xlsx");
                }
            }
        }

        public List<CategoryModel> CategoryTitleList()
        {
            List<CategoryModel> cm = new List<CategoryModel>();
            {
                using (var c = new Context())
                {
                    cm = c.CategoryTables.Select(x => new CategoryModel
                    {
                        CategoryName = x.CategoryName,
                        CategoryImages = x.CategoryImages,
                        CategoryCreateDate = x.CategoryCreateDate,
                        CategoryStok = x.CategoryStok,
                        GenderID = x.GenderID

                    }).ToList();
                }
            }
            return cm;
        }
    }
}

    

