using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MessageTable
    {
        [Key]
        public int MessageID { get; set; }



        [Required]
        [StringLength(50)]
        public string UserAdminName { get; set; }




        [Required]
        [StringLength(50)]
        public string Email { get; set; }



        public DateTime CreateDate { get; set; } = DateTime.Now;




        [Required]
        [StringLength(200)]
        public string MessageText { get; set; }






        
        [StringLength(60)]
        public string MessageTitle { get; set; }
    }
}
