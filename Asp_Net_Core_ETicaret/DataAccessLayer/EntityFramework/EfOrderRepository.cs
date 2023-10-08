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
    public class EfOrderRepository:GenericRepository<OrderTable>,IOrderDal
    {
        List<OrderTable> IOrderDal.GetListWithProduct()
        {
            using var c = new Context();
            return c.OrderTables.Include(x => x.Product).ToList();
        }
    }
}
