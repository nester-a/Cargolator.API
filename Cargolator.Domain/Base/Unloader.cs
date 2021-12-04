using Cargolator.API.Base.AbstractClasses;
using Cargolator.API.Base.Enums;
using Cargolator.API.Base.EventArgs;
using Cargolator.API.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base
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
            if(TakedCargo is null && container.GetCount() > 0)
            {
                Unload(container);
                return true;
            }
            if (container.GetCount() <= 0)
            {
                UnloadCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Unloader)} cannot unload any cargo from this container. It's empty", false));
                return false;
            }
            UnloadCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Unloader)} cannot unload cargo from this container.", false));
            return false;
        }

        public void Unload(ILoadable container)
        {
            if (container is null) throw new ArgumentNullException("Container", "Container is null");
            if (container.GetCount() == 0) throw new InvalidOperationException($"Container is empty");
            if (TakedCargo is not null) throw new InvalidOperationException($"This {nameof(Unloader)} taked cargo is not null");
            TryTake(container.RemoveCargo());
            UnloadCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Unloader)} successfully unload the cargo {TakedCargo.Id} from the container", true));
        }

        public void PlaceToStock(IStock stock)
        {
            if (stock is null) throw new ArgumentNullException("Stock", "Stock is null");
            if (TakedCargo is null) throw new InvalidOperationException($"This {nameof(Unloader)} taked cargo is null");
            stock.AddCargo(TakedCargo);
            PlaceToStockCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Unloader)} successfully place the cargo {TakedCargo.Id} to stock", true));
            TryDropCargo(CargoStatus.OnStock);
        }

        public bool TryPlaceToStock(IStock stock)
        {
            if (TakedCargo is not null && stock is not null)
            {
                PlaceToStock(stock);
                return true;
            }
            PlaceToStockCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Unloader)} cannot place the cargo. He doesn't have it.", false));
            return false;
        }
    }
}
