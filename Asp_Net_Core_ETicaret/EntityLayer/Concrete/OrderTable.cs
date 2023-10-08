using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class OrderTable
    {
        [Key]
        public int OrderID { get; set; }


        //[Required]
        //[StringLength(200)]

        //public string NameSurname { get; set; }

        [Required]
        [StringLength(200)]

        public string Address { get; set; }


        public int CustomerPhoneNumber { get; set; }



        public DateTime OrderCreateDate { get; set; } = DateTime.Now;




        public Guid ID { get; set; }



        public int ProductID { get; set; }
        public ProductTable Product { get; set; }





        public List<CargoTable> Cargos { get; set; }







    }
}
