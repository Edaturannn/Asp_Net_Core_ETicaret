namespace Asp_Net_Core_ETicaret.Areas.AdminOperations.Models
{
    public class UserAdminModel
    {
        
        public Guid ID { get; set; }

        public string NameSurname { get; set; }

       


        public DateTime CreateDate { get; set; } = DateTime.Now;

        public bool Locked { get; set; } = true;

        public string Role { get; set; } = "user";


     
        public string Address { get; set; } = "no-address";

     
        public string Gender { get; set; } = "no-gender";
    }
}
