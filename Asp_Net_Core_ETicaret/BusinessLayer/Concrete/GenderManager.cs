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
    public class GenderManager : IGenderService
    {
        IGenderDal _genderDal;
        public GenderManager(IGenderDal genderDal)
        {
            _genderDal = genderDal;
        }

        public List<GenderTable> GetListAllGender()
        {
            return _genderDal.GetListAll();
        }

        public void TAdd(GenderTable t)
        {
            _genderDal.Insert(t);
        }

        public void TDelete(GenderTable t)
        {
            _genderDal.Delete(t);
        }

        public GenderTable TGetByGUID(Guid guid)
        {
            return _genderDal.GetByGUID(guid);
        }

        public GenderTable TGetByID(int id)
        {
            return _genderDal.GetByID(id);
        }

        public List<GenderTable> TGetList(GenderTable t)
        {
            return _genderDal.GetListAll();
        }

        public void TUpdate(GenderTable t)
        {
            _genderDal.Update(t);
        }
    }
}
