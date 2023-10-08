using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOrderService:IGenericService<OrderTable>
    {
        List<OrderTable> GetListAllOrder();

        List<OrderTable> GetListProduct();

        List<OrderTable> GetListProductID(int id);


        List<OrderTable> GetListUserAdminGuid(Guid guid);


        List<OrderTable> GetListOrderID(int id);
    }
}
