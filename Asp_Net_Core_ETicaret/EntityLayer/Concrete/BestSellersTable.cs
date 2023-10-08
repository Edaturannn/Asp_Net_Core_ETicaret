using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BestSellersTable
    {
        [Key]
        public int BestSellersID { get; set; }

        public string BestSellersName { get; set; }
        

        public string BestSellersTitle { get; set; }


        public string BestSellersDescription { get; set;}

        public string BestSellersImages { get; set; }

        public int BestSellersPrice { get; set; }

        public DateTime BestSellersCreateDate { get; set; } = DateTime.Now;
    }
}
