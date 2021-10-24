using Cargolator.Domain.Base.AbstractClasses;
using Cargolator.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base
{
    public class Unloader : Worker, IUnloader
    {
        public bool TryUnload(ILoadable container)
        {
            if(TakedCargo is null)
            {
                Unload(container);
                return true;
            }
            return false;
        }
        public void Unload(ILoadable container)
        {
            TakedCargo = container.LoadedCargo.Pop();
        }

        public bool PlaceToStock(IStock stock)
        {
            if (TakedCargo is not null)
            {
                stock.CargosStock.Enqueue(TakedCargo);
                TakedCargo = null;
                return true;
            }
            return false;
        }
    }
}
