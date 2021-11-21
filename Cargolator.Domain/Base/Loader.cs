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
    public class Loader : Worker, ILoader
    {
        public event WorkerHandler LoadCargoEvent;
        public event WorkerHandler TakeFromStockCargoEvent;
        public event WorkerHandler RotateCargoEvent;
        public Loader()
        {
            ThisWorkerType = WorkerType.Loader;
        }
        public void Load(ILoadable container)
        {
            container.LoadedCargo.Push(TakedCargo);
            LoadCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} successfully load the cargo {TakedCargo.Id} to the container.", true));
            TryDropCargo(CargoStatus.InContainer);
        }

        public bool TryLoad(ILoadable container)
        {
            if (TakedCargo is not null && container is not null)
            {
                Load(container);
                return true;
            }
            if (container is null)
            {
                LoadCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} cannot load the cargo {TakedCargo.Id} to the container. Container is not created.", false));
                return false;
            }
            LoadCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} cannot load the cargo {TakedCargo.Id} to the container. He doesn't have it.", false));
            return false;
        }

        public void Rotate()
        {
            int tmp = TakedCargo.Length;
            TakedCargo.Length = TakedCargo.Width;
            TakedCargo.Width = tmp;
            RotateCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} rotate the cargo {TakedCargo.Id}.", true));
        }
        public bool TryRotate()
        {
            if (TakedCargo is not null && TakedCargo.Length != TakedCargo.Width)
            {
                Rotate();
                return true;
            }
            RotateCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} cannot rotate the cargo {TakedCargo.Id}.", false));
            return false;
        }

        public void TakeFromStock(IStock stock)
        {
            Take(stock.CargosStock.Dequeue());
            TakeFromStockCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} successfully take the cargo {TakedCargo.Id} from stock.", true));
        }

        public bool TryTakeFromStock(IStock stock)
        {
            if (TakedCargo is null && stock.CargosStock.Count > 0)
            {
                TakeFromStock(stock);
                return true;
            }
            TakeFromStockCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} cannot take the cargo {TakedCargo.Id} from stock.", false));
            return false;
        }
    }
}
