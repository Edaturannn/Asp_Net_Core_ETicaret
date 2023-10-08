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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<CategoryTable> GetListAllCategory()
        {
            return _categoryDal.GetListAll();
        }

        public List<CategoryTable> GetListByGenderID(int id)
        {
            return _categoryDal.GetListAll(x => x.GenderID == id);
        }

        public void TAdd(CategoryTable t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(CategoryTable t)
        {
            _categoryDal.Delete(t);
        }

        public CategoryTable TGetByGUID(Guid guid)
        {
            return _categoryDal.GetByGUID(guid);
        }

        public CategoryTable TGetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<CategoryTable> TGetList(CategoryTable t)
        {
            return _categoryDal.GetListAll();
        }

        public void TUpdate(CategoryTable t)
        {
            _categoryDal.Update(t);
        }
    }
}
