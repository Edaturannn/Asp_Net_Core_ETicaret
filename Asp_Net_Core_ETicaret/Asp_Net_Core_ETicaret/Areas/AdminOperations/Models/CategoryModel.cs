using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Models
{
    public class CategoryModel
    {
       
        public int CategoryID { get; set; }


       
        public string CategoryName { get; set; }


       
        public string CategoryImages { get; set; }


       
        public DateTime CategoryCreateDate { get; set; } = DateTime.Now;


        public int? CategoryStok { get; set; } = 100;




        //Gender Id si ile ilişki kurması gerekiyor çünkü o ID ye göre kadın veya erkek Category getirecek...
        public int GenderID { get; set; }
        public GenderTable Gender { get; set; }
    }
}
