using EntityLayer.Concrete;

namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Models
{
    public class CargoModel
    {
        public int CargoID { get; set; }


        public string CargoName { get; set; } = "PTT";


        public DateTime CargoCreateDate { get; set; } = DateTime.Now;




        public int PhoneNumber { get; set; }

        public string Country { get; set; }

        public string City { get; set; }


        public string NameSurname { get; set; }



        //Order Table ile ilişki kurmalıyız....

        public int OrderID { get; set; }
        public OrderTable Order { get; set; }
    }
}
