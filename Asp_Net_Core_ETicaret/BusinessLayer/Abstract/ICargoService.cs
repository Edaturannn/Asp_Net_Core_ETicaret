using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICargoService:IGenericService<CargoTable>
    {
        List<CargoTable> GetListAllCargo();
        List<CargoTable> GetListByOrderID(int id);
        List<CargoTable> GetListCargo();
    }
}
