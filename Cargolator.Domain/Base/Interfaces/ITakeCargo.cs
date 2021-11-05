using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.Interfaces
{
    public interface ITakeCargo
    {
        ICargo TakedCargo { get; }
        void Take(ICargo cargo);
        bool TryTake(ICargo cargo);
    }
}
