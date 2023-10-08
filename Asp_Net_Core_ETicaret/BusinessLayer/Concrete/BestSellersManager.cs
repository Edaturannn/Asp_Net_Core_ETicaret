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
    public class BestSellersManager : IBestSellersService
    {
        IBestSellersDal _bestsellersDal;
        public BestSellersManager(IBestSellersDal bestsellersDal)
        {
            _bestsellersDal = bestsellersDal;
        }

        public List<BestSellersTable> GetListAllBestSellers()
        {
            return _bestsellersDal.GetListAll();
        }

        public List<BestSellersTable> GetListBestSellersID(int id)
        {
            return _bestsellersDal.GetListAll(x => x.BestSellersID == id);
        }

        public void TAdd(BestSellersTable t)
        {
            _bestsellersDal.Insert(t);
        }

        public void TDelete(BestSellersTable t)
        {
            _bestsellersDal.Delete(t);
        }

        public BestSellersTable TGetByGUID(Guid guid)
        {
            throw new NotImplementedException();
        }

        public BestSellersTable TGetByID(int id)
        {
            return _bestsellersDal.GetByID(id);
        }

        public List<BestSellersTable> TGetList(BestSellersTable t)
        {
            return _bestsellersDal.GetListAll();
        }

        public void TUpdate(BestSellersTable t)
        {
            _bestsellersDal.Update(t);
        }
    }
}
