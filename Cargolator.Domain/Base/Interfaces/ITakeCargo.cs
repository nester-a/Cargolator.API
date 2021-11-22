using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.Interfaces
{
    public interface ITakeCargo
    {
        Cargo TakedCargo { get; }
        void Take(Cargo cargo);
        bool TryTake(Cargo cargo);
    }
}
