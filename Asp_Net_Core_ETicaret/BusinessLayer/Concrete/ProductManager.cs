using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<ProductTable> GetListAllProduct()
        {
            return _productDal.GetListAll();
        }

        public List<ProductTable> GetListByCategoryID(int id)
        {
            return _productDal.GetListAll(x => x.CategoryID == id);
        }

        public List<ProductTable> GetListCategory()
        {
            return _productDal.GetListWithCategory();
        }

        public List<ProductTable> GetListProductID(int id)
		{
            return _productDal.GetListAll(x => x.ProductID == id);
		}

		public void TAdd(ProductTable t)
        {
            _productDal.Insert(t);
        }

        public void TDelete(ProductTable t)
        {
            _productDal.Delete(t);
        }

        public ProductTable TGetByGUID(Guid guid)
        {
            return _productDal.GetByGUID(guid);
        }

        public ProductTable TGetByID(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<ProductTable> TGetList(ProductTable t)
        {
            return _productDal.GetListAll();
        }

        public void TUpdate(ProductTable t)
        {
            _productDal.Update(t);
        }
    }
}
