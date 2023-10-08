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
    public class CargoManager : ICargoService
    {
        ICargoDal _cargoDal;
        public CargoManager(ICargoDal cargoDal)
        {
            _cargoDal = cargoDal;
        }

        public List<CargoTable> GetListAllCargo()
        {
            return _cargoDal.GetListAll();
        }

        public List<CargoTable> GetListByOrderID(int id)
        {
            return _cargoDal.GetListAll(x => x.OrderID == id);
        }

        public List<CargoTable> GetListCargo()
        {
            return _cargoDal.GetListWithOrder();
        }

        public void TAdd(CargoTable t)
        {
            _cargoDal.Insert(t);
        }

        public void TDelete(CargoTable t)
        {
            _cargoDal.Delete(t);
        }

        public CargoTable TGetByGUID(Guid guid)
        {
            throw new NotImplementedException();
        }

        public CargoTable TGetByID(int id)
        {
            return _cargoDal.GetByID(id);
        }

        public List<CargoTable> TGetList(CargoTable t)
        {
            return _cargoDal.GetListAll();
        }

        public void TUpdate(CargoTable t)
        {
            _cargoDal.Update(t);
        }
    }
}
