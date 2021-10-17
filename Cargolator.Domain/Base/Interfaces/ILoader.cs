using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base.Interfaces
{
    public interface ILoader
    {
        ICargo TakedCargo { get; }
        void Take(ICargo cargo);
        bool TryTake(ICargo cargo);
        void Load(ILoadable container);
        bool TryLoad(ILoadable container, ICoordinates placeForLoad);
        void Rotate();
    }
}
