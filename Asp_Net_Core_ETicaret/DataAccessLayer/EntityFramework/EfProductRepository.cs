using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductRepository:GenericRepository<ProductTable>,IProductDal
    {
        List<ProductTable> GetListByCategoryID(int id)
        {
            using var c = new Context();
            return c.ProductTables.Include(x => x.Category).Where(x => x.CategoryID == id).ToList();
        }

        List<ProductTable> IProductDal.GetListWithCategory()
        {
            using var c = new Context();
            return c.ProductTables.Include(x => x.Category).ToList();
        }
    }
}
