using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICargoDal:IGenericDal<CargoTable>
    {
        List<CargoTable> GetListWithOrder();
    }
}
