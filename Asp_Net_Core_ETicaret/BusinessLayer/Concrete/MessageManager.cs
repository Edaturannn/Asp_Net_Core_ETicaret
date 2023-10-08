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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<MessageTable> GetListAllMessage()
        {
            return _messageDal.GetListAll();
        }

        public void TAdd(MessageTable t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(MessageTable t)
        {
            _messageDal.Delete(t);
        }

        public MessageTable TGetByGUID(Guid guid)
        {
            return _messageDal.GetByGUID(guid);
        }

        public MessageTable TGetByID(int id)
        {
            return _messageDal.GetByID(id);
        }

        public List<MessageTable> TGetList(MessageTable t)
        {
            return _messageDal.GetListAll();
        }

        public void TUpdate(MessageTable t)
        {
            _messageDal.Update(t);
        }
    }
}
