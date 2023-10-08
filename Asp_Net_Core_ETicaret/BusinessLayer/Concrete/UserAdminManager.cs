using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserAdminManager : IUserAdminService
    {
        IUserAdminDal _useradminDal;
        public UserAdminManager(IUserAdminDal userAdminDal)
        {
            _useradminDal= userAdminDal;
        }

        public UserAdminTable TGetByGUID(Guid guid)
        {
            return _useradminDal.GetByGUID(guid);
        }

        public UserAdminTable TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserAdminTable> GetListAllUser()
        {
            return _useradminDal.GetListAll();
        }

        public void TAdd(UserAdminTable t)
        {
            _useradminDal.Insert(t);
        }

        public void TDelete(UserAdminTable t)
        {
            _useradminDal.Delete(t);
        }

        public List<UserAdminTable> TGetList(UserAdminTable t)
        {
            return _useradminDal.GetListAll();
        }

        public void TUpdate(UserAdminTable t)
        {
            _useradminDal.Update(t);
        }
    }
}
