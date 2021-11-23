using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.Interfaces
{
    public interface IAddCargo
    {
        void AddRangeCargo(params Cargo[] cargos);
        void AddCargo(Cargo cargo);
        void AddRangeCargo(ICollection<Cargo> cargos);
    }
}
