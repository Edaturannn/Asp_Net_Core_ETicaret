using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CommentTable
    {
        [Key]
        public int CommentID { get; set; }


        [StringLength(200)]
        public string CommentMessage { get; set; }


        [Required]
        public DateTime CommentCreateDate { get; set; } = DateTime.Now;


        //ProductTable arasında bir ilişki kurmam gerekiyor çünkü seçilen ürüne göre yorum yapacagım...

        public int ProductID { get; set; }
        public ProductTable Product { get; set; }




        //UserAdmin arasında bir ilişki kuramam gerekiyor çünkü seçen username göre işlem yapacak...

        public Guid ID { get; set; }
    }
}
