using Cargolator.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base
{
    public class Loader : ILoader
    {
        public ICargo TakedCargo { get; private set; }

        public void Load(ILoadable container)
        {
            container.LoadedCargo.Push(TakedCargo);
            TakedCargo = null;
        }

        public bool TryLoad(ILoadable container, ICoordinates placeForLoad)
        {
            throw new NotImplementedException();
        }

        public void Take(ICargo cargo)
        {
            TakedCargo = cargo;
        }

        public bool TryTake(ICargo cargo)
        {
            if (TakedCargo is null)
            {
                Take(cargo);
                return true;
            }
            return false;
        }

        public void Rotate()
        {
            int tmp = TakedCargo.Length;
            TakedCargo.Length = TakedCargo.Width;
            TakedCargo.Width = tmp;
        }
    }
}
