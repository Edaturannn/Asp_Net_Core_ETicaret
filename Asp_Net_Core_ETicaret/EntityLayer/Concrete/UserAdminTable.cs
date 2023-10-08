using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserAdminTable
    {
        [Key]
        public Guid ID { get; set; }


        [Required]
        [StringLength(50)]
        public string NameSurname { get; set; }

        [Required]
        [StringLength(120)]
        public string Password { get; set; }


        public DateTime CreateDate { get; set; } = DateTime.Now;

        public bool Locked { get; set; } = true;


        [StringLength(10)]
        public string Role { get; set; } = "user";


        [StringLength(250)]
        public string Address { get; set; } = "no-address";

        [StringLength(10)]
        public string Gender { get; set; } = "no-gender";


        public string ProfileImages { get; set; } = "no-profile.jpg";



        //CommentTable ile ilişki kuracagız...

        public List<CommentTable> Comments { get; set; }


        public List<OrderTable> Orders { get; set; } 
    }
}
