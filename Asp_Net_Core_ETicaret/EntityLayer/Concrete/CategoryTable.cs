using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CategoryTable
    {
        [Key]
        public int CategoryID { get; set; }


        [Required]
        [StringLength(70)]
        public string CategoryName { get; set; }


        [Required]
        [StringLength(310)]
        public string CategoryImages { get; set; }


        [Required]
        public DateTime CategoryCreateDate { get; set; } = DateTime.Now;


        public int? CategoryStok { get; set; } = 100;




        //Gender Id si ile ilişki kurması gerekiyor çünkü o ID ye göre kadın veya erkek Category getirecek...
        public int GenderID { get; set; }
        public GenderTable Gender { get; set; }

        //Category ID sine göre bu sefer ürünler gelmesi gerekiyor bu yüzden Product tablosu ile ilişki kuracagim...
        public List<ProductTable> Products { get; set; }
    }
}
