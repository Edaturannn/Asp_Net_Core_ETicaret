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
    public class EfCategoryRepository:GenericRepository<CategoryTable>,ICategoryDal
    {
        List<GenderTable> GetListByGenderID(int id)
        {
            using var c = new Context();
            return c.GenderTables.Include(x => x.Gender).Where(x => x.GenderID == id).ToList();
        }
    }
}
