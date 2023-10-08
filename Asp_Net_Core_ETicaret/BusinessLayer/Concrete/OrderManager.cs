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
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public List<OrderTable> GetListAllOrder()
        {
            return _orderDal.GetListAll();
        }

        public List<OrderTable> GetListOrderID(int id)
        {
            return _orderDal.GetListAll(x => x.OrderID == id);
        }

        public List<OrderTable> GetListProduct()
        {
            return _orderDal.GetListWithProduct();
        }

        public List<OrderTable> GetListProductID(int id)
        {
            return _orderDal.GetListAll(x => x.ProductID == id);
        }

        public List<OrderTable> GetListUserAdminGuid(Guid guid)
        {
            return _orderDal.GetListAll(x => x.ID == guid);
        }

        public void TAdd(OrderTable t)
        {
            _orderDal.Insert(t);
        }

        public void TDelete(OrderTable t)
        {
            _orderDal.Delete(t);
        }

        public OrderTable TGetByGUID(Guid guid)
        {
            return _orderDal.GetByGUID(guid);
        }

        public OrderTable TGetByID(int id)
        {
            return _orderDal.GetByID(id);
        }

        public List<OrderTable> TGetList(OrderTable t)
        {
            return _orderDal.GetListAll();
        }

        public void TUpdate(OrderTable t)
        {
            _orderDal.Update(t);
        }
    }
}
