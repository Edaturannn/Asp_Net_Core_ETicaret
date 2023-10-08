using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class GenderTable
    {
        [Key]
        public int GenderID { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string GenderImages { get; set; }


        //Category ile ilişki kuracagız çünkü seçilen Gender ID ye göre kullanıcının cinsiyetine göre category getirecek...
        public List<CategoryTable> Categories { get; set; }
    }
}
