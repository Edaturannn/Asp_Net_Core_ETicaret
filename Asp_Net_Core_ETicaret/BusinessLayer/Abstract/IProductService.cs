using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<ProductTable>
    {
        List<ProductTable> GetListAllProduct();

        List<ProductTable> GetListCategory();

        List<ProductTable> GetListByCategoryID(int id);

        List<ProductTable> GetListProductID(int id);

	}
}
