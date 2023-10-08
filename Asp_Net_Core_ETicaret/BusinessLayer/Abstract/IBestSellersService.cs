using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBestSellersService:IGenericService<BestSellersTable>
    {
        List<BestSellersTable> GetListAllBestSellers();

        List<BestSellersTable> GetListBestSellersID(int id);
    }
}
