using Cargolator.Domain.Base.AbstractClasses;
using Cargolator.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base
{
    public class Loader : Worker, ILoader
    {
        public void Load(ILoadable container)
        {
            container.LoadedCargo.Push(TakedCargo);
            TakedCargo = null;
        }

        public bool TryLoad(ILoadable container)
        {
            if (TakedCargo is null)
            {
                Load(container);
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
