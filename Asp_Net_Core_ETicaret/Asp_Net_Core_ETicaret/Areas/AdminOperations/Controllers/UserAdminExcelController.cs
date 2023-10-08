using Asp_Net_Core_ETicaret.Areas.AdminOperations.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminOperations")]
    public class UserAdminExcelController : Controller
    {
        public IActionResult UserAdminExcelCreate()
        {
            using (var WorkBook = new XLWorkbook())
            {
                var WorkSheet = WorkBook.Worksheets.Add("User Admin List");

                WorkSheet.Cell(1, 1).Value = "Name Surname";
                WorkSheet.Cell(1, 2).Value = "Create Date";
                WorkSheet.Cell(1, 3).Value = "Locked";

                WorkSheet.Cell(1, 4).Value = "Role";
                WorkSheet.Cell(1, 5).Value = "Address";
                WorkSheet.Cell(1, 6).Value = "Gender";
                int UserAdminRowCount = 7;
                foreach (var item in UserAdminTitleList())
                {
                    WorkSheet.Cell(UserAdminRowCount, 1).Value = item.NameSurname;

                    WorkSheet.Cell(UserAdminRowCount, 2).Value = item.CreateDate;

                    WorkSheet.Cell(UserAdminRowCount, 3).Value = item.Locked;

                    WorkSheet.Cell(UserAdminRowCount, 4).Value = item.Role;

                    WorkSheet.Cell(UserAdminRowCount, 5).Value = item.Address;

                    WorkSheet.Cell(UserAdminRowCount, 6).Value = item.Gender;
                    UserAdminRowCount++;
                }
                using (var Stream = new MemoryStream())
                {
                    WorkBook.SaveAs(Stream);
                    var Content = Stream.ToArray();
                    return File(Content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "useradminlist.xlsx");
                }
            }
        }
        public List<UserAdminModel> UserAdminTitleList()
        {
            List<UserAdminModel> um = new List<UserAdminModel>();
            {
                using (var c = new Context())
                {
                    um = c.UserAdminTables.Select(x => new UserAdminModel
                    {
                        NameSurname = x.NameSurname,
                        CreateDate = x.CreateDate,
                        Locked = x.Locked,
                        Role = x.Role,
                        Address = x.Address,
                        Gender = x.Gender
                    }).ToList();
                }
            }
            return um;
        }
    }
}
