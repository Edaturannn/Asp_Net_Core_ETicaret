using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Models
{
    public class ProductModel
    {
       
        public int ProductID { get; set; }


     
        public string ProductName { get; set; }


        public string ProductTitle { get; set; }


        public string ProductDescription { get; set; }


     
        public string ProductImages { get; set; }

       
        public int ProductPrice { get; set; }

       
        public int ProductStok { get; set; } = 100;


        
        public DateTime ProductCreateDate { get; set; } = DateTime.Now;


        //Seçilen Category ID sine göre ürünler gelecek bu yüzden ilişki kuracagım...
        public int CategoryID { get; set; }
        public CategoryTable Category { get; set; }

    }
}
