using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        List<T> GetListAll();

        T GetByGUID(Guid guid);//ID si Guid olanı bulur...

        T GetByID(int id);//ID si int olanı bulur...
        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }
}
