using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base.Interfaces
{
    public interface ITakeCargo
    {
        ICargo TakedCargo { get; }
        void Take(ICargo cargo);
        void TakeFromStock(IStock stock);
        bool TryTakeFromStock(IStock stock);
        bool TryTake(ICargo cargo);
    }
}
