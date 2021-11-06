using Cargolator.API.Base.Enums;
using Cargolator.API.Base.EventArgs;
using Cargolator.API.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.AbstractClasses
{
    public abstract class Worker : ITakeCargo
    {
        public delegate void WorkerHandler(object sender, WorkerEventArgs e);
        public event WorkerHandler TakeCargoEvent;
        public event WorkerHandler DropCargoEvent;
        protected WorkerType ThisWorkerType;
        public ICargo TakedCargo { get; private set; }
        public void Take(ICargo cargo)
        {
            TakedCargo = cargo;
            TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} successfully took the cargo {cargo.Id}", true));
        }
        public bool TryTake(ICargo cargo)
        {
            if (TakedCargo is null)
            {
                Take(cargo);
                return true;
            }
            TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} cannot take the cargo {cargo.Id}. He has already taken the cargo {TakedCargo.Id}", false));
            return false;
        }
        public void DropCargo()
        {
            TakedCargo = null;
            TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} successfully drop his cargo.", true));
        }
        public bool TryDropCargo()
        {
            if (TakedCargo is not null)
            {
                DropCargo();
                return true;
            }
            TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} cannot drop his cargo. He doesn't have it.", false));
            return false;
        }
        public void TakeFromWorker(ref Worker worker)
        {
            this.TryTake(worker.TakedCargo);
            worker.TryDropCargo();
            TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} successfully took the cargo {TakedCargo.Id} from other worker ({nameof(worker.ThisWorkerType)})", true));
        }
        public bool TryTakeFromWorker(ref Worker worker)
        {
            if(worker is not null && worker.TakedCargo is not null && this.TakedCargo is null)
            {
                TakeFromWorker(ref worker);
                return true;
            }
            else if(worker is null)
            TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} can't take the cargo from other worker ({nameof(worker.ThisWorkerType)})", true));
            return false;
        }
    }
}
