using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProductTable
    {
        [Key]
        public int ProductID { get; set; }


        [Required]
        [StringLength(70)]
        public string ProductName { get; set; }



        [Required]
        [StringLength(70)]
        public string ProductTitle { get; set; }


        [Required]
        [StringLength(300)]
        public string ProductDescription { get; set; }


        [Required]
        [StringLength(310)]
        public string ProductImages { get; set; }

        [Required]
        public int ProductPrice { get; set; }

        [Required]
        public int ProductStok { get; set; } = 100;


        [Required]
        public DateTime ProductCreateDate { get; set; } = DateTime.Now;


        //Seçilen Category ID sine göre ürünler gelecek bu yüzden ilişki kuracagım...
        public int CategoryID { get; set; }
        public CategoryTable Category { get; set; }




        //Seçilen Ürünün ID sine göre yorum yapılacak...
        public List<CommentTable> Comments { get; set; }




        public List<OrderTable> Orders { get; set; }
    }
}
