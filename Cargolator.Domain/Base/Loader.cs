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
            if (container is null) throw new ArgumentNullException("Container", "Container parameter is null");
            if (TakedCargo is null) throw new NullReferenceException($"This {nameof(Loader)} taked cargo is null");
            container.AddCargo(TakedCargo);
            LoadCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Loader)} successfully load the cargo {TakedCargo.Id} to the container.", true));
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
                LoadCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Loader)} cannot load the cargo {TakedCargo.Id} to the container. Container is not created.", false));
                return false;
            }
            LoadCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Loader)} cannot load the cargo {TakedCargo.Id} to the container. He doesn't have it.", false));
            return false;
        }

        public void Rotate()
        {
            if (TakedCargo is null) throw new NullReferenceException($"This {nameof(Loader)} taked cargo is null");
            int tmp = TakedCargo.Length;
            TakedCargo.Length = TakedCargo.Width;
            TakedCargo.Width = tmp;
            RotateCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Loader)} rotate the cargo {TakedCargo.Id}.", true));
        }

        public bool TryRotate()
        {
            if (TakedCargo is not null && TakedCargo.Length != TakedCargo.Width)
            {
                Rotate();
                return true;
            }
            if(TakedCargo is null)
            {
                RotateCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Loader)} has no any cargo for rotate.", false));
                return false;
            }
            RotateCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Loader)} cannot rotate the cargo {TakedCargo.Id}.", false));
            return false;
        }

        public void TakeFromStock(IStock stock)
        {
            if (stock is null) throw new ArgumentNullException("Stock", "Stock is null");
            if (stock.GetCount() == 0) throw new InvalidOperationException("Stock is empty");
            if (TakedCargo is not null) throw new InvalidOperationException($"This {nameof(Loader)} taked cargo is not null");
            Take(stock.RemoveCargo());
            TakeFromStockCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Loader)} successfully take the cargo {TakedCargo.Id} from stock.", true));
        }

        public bool TryTakeFromStock(IStock stock)
        {
            if (TakedCargo is null && stock.GetCount() > 0)
            {
                TakeFromStock(stock);
                return true;
            }
            TakeFromStockCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Loader)} cannot take the cargo from stock.", false));
            return false;
        }
    }
}
