using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.Interfaces
{
    public interface IAddCargo
    {
        void AddRangeCargo(params ICargo[] cargos);
        void AddCargo(ICargo cargo);
        void AddRangeCargo(ICollection<Cargo> cargos);
    }
}
