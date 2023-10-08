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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<CommentTable> GetListAllComment()
        {
            return _commentDal.GetListAll();
        }

        public List<CommentTable> GetListByProductID(int id)
        {
            return _commentDal.GetListAll(x => x.ProductID == id);
        }

        public List<CommentTable> GetListByUserAdminID(Guid guid)
        {
            return _commentDal.GetListAll(x => x.ID == guid);
        }

        public List<CommentTable> GetListProduct()
        {
            return _commentDal.GetListWithProduct();
        }

        public List<CommentTable> GetListUserAdmin()
        {
            return _commentDal.GetListWithUserAdmin();
        }

        public void TAdd(CommentTable t)
        {
            _commentDal.Insert(t);
        }

        public void TDelete(CommentTable t)
        {
            _commentDal.Delete(t);
        }

        public CommentTable TGetByGUID(Guid guid)
        {
            return _commentDal.GetByGUID(guid);
        }

        public CommentTable TGetByID(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<CommentTable> TGetList(CommentTable t)
        {
            return _commentDal.GetListAll();
        }

        public void TUpdate(CommentTable t)
        {
            _commentDal.Update(t);
        }
    }
}
