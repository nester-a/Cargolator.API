using Cargolator.Domain.Base.AbstractClasses;
using Cargolator.Domain.Base.Enums;
using Cargolator.Domain.Base.EventArgs;
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
        public event WorkerHandler UnloadCargoEvent;
        public event WorkerHandler PlaceToStockCargoEvent;
        public Unloader()
        {
            ThisWorkerType = WorkerType.Unloader;
        }
        public bool TryUnload(ILoadable container)
        {
            if(TakedCargo is null && container.LoadedCargo.Count > 0)
            {
                Unload(container);
                return true;
            }
            if (container.LoadedCargo.Count <= 0)
            {
                UnloadCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} cannot unload any cargo from this container. It's empty", false));
                return false;
            }
            UnloadCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} cannot unload cargo from this container.", false));
            return false;
        }
        public void Unload(ILoadable container)
        {
            TryTake(container.LoadedCargo.Pop());
            UnloadCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} successfully unload the cargo {TakedCargo.Id} from the container", true));
        }

        public void PlaceToStock(IStock stock)
        {
            stock.CargosStock.Enqueue(TakedCargo);
            PlaceToStockCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} successfully place the cargo {TakedCargo.Id} to stock", true));
            TryDropCargo();
        }

        public bool TryPlaceToStock(IStock stock)
        {
            if (TakedCargo is not null && stock is not null)
            {
                PlaceToStock(stock);
                return true;
            }
            PlaceToStockCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} cannot place the cargo. He doesn't have it.", false));
            return false;
        }
        
    }
}
