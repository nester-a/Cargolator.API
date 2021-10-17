using Cargolator.Domain.Base.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base.Interfaces
{
    public class Unloader : Worker, IUnloader
    {
        public void PlaceOnStock(IStock stock)
        {
            stock.CargosStock.Enqueue(TakedCargo);
            TakedCargo = null;
        }
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
    }
}
