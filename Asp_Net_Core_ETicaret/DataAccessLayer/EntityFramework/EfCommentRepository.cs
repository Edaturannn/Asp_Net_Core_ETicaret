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
    public class EfCommentRepository:GenericRepository<CommentTable>,ICommentDal
    {
        List<CommentTable> GetListByProductID(int id)
        {
            using var c = new Context();
            return c.CommentTables.Include(x => x.Product).Where(x => x.ProductID == id).ToList();
        }

        List<CommentTable> GetListByUserAdminID(Guid guid)
        {
            using var c = new Context();
            return c.CommentTables.Include(x => x.ID).Where(x => x.ID == guid).ToList();
        }

        List<CommentTable> ICommentDal.GetListWithUserAdmin()
        {
            using var c = new Context();
            return c.CommentTables.Include(x => x.ID).ToList();
        }

        List<CommentTable> ICommentDal.GetListWithProduct()
        {
            using var c = new Context();
            return c.CommentTables.Include(x => x.Product).ToList();
        }
    }
}
