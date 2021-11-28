using Cargolator.API.Base.Enums;
using Cargolator.API.Base.EventArgs;
using Cargolator.API.Base.Interfaces;
using System;

namespace Cargolator.API.Base.AbstractClasses
{
    public abstract class Worker : ITakeFromWorker
    {
        public delegate void WorkerHandler(object sender, WorkerEventArgs e);
        public event WorkerHandler TakeCargoEvent;
        public event WorkerHandler DropCargoEvent;
        public event WorkerHandler TakeCargoFromWorkerEvent;

        public WorkerType ThisWorkerType { get; protected set; }
        public Cargo TakedCargo { get; private set; }

        public void Take(Cargo cargo)
        {
            if (cargo is null) throw new ArgumentNullException("Cargo", "Cargo parameter is null");
            if (cargo.Status == CargoStatus.OnHands) throw new ArgumentException("Cargo has wrong status", $"Cargo #{cargo.Id}");
            if (TakedCargo is not null) throw new InvalidOperationException($"This {nameof(Worker)} taked cargo is not null");
            TakedCargo = cargo;
            TakedCargo.ChangeStatus(CargoStatus.OnHands);
            TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Worker)} successfully took the cargo {cargo.Id}", true));
        }

        public bool TryTake(Cargo cargo)
        {
            if (TakedCargo is null && cargo is not null && cargo.Status != CargoStatus.OnHands)
            {
                Take(cargo);
                return true;
            }
            if(TakedCargo is not null)
            {
                TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Worker)} cannot take the cargo {cargo.Id}. He has already taken the cargo {TakedCargo.Id}", false));
                return false;
            }
            if(cargo is null)
            {
                TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Worker)} cannot take the cargo.", false));
                return false;
            }
            TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Worker)} cannot take the cargo {cargo.Id}. It's already taken by somebody", false));
            return false;
        }

        public void DropCargo()
        {
            if (TakedCargo is null) throw new NullReferenceException($"This {nameof(Worker)} taked cargo is null");
            TakedCargo.ChangeStatus(CargoStatus.Wait);
            TakedCargo = null;
            DropCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Worker)} successfully drop his cargo.", true));
        }

        public void DropCargo(CargoStatus dropedCargoStatus)
        {
            if (TakedCargo is null) throw new NullReferenceException($"This {nameof(Worker)} taked cargo is null");
            if (dropedCargoStatus == CargoStatus.OnHands) throw new ArgumentException("Droped cargo status cannot be OnHands");
            TakedCargo.ChangeStatus(dropedCargoStatus);
            TakedCargo = null;
            DropCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Worker)} successfully drop his cargo.", true));
        }

        public bool TryDropCargo()
        {
            if (TakedCargo is not null)
            {
                DropCargo();
                return true;
            }
            DropCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Worker)} cannot drop his cargo. He doesn't have it.", false));
            return false;
        }

        public bool TryDropCargo(CargoStatus dropedCargoStatus)
        {
            if (TakedCargo is not null && dropedCargoStatus != CargoStatus.OnHands)
            {
                DropCargo(dropedCargoStatus);
                return true;
            }
            if(TakedCargo is null)
            {
                DropCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Worker)} cannot drop his cargo. He doesn't have it.", false));
                return false;
            }
            DropCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Worker)} cannot drop his cargo with this wrong status.", false));
            return false;
        }

        public void TakeFromWorker(ITakeFromWorker worker)
        {
            if (worker is null) throw new ArgumentNullException("Worker","Worker parameter is null");
            if (worker == this) throw new InvalidOperationException($"This {nameof(Worker)} cannot take the cargo from himself");
            if (worker.TakedCargo is null) throw new NullReferenceException($"This worker parameter taked cargo is null");
            if (TakedCargo is not null) throw new InvalidOperationException($"This {nameof(Worker)} taked cargo is not null");
            worker.TakedCargo.ChangeStatus(CargoStatus.Wait);
            TryTake(worker.TakedCargo);
            worker.TryDropCargo();
            TakedCargo.ChangeStatus(CargoStatus.OnHands);
            TakeCargoFromWorkerEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Worker)} successfully took the cargo {TakedCargo.Id} from other {nameof(Worker)}", true));
        }

        public bool TryTakeFromWorker(ITakeFromWorker worker)
        {
            if(worker is not null && worker.TakedCargo is not null && TakedCargo is null)
            {
                TakeFromWorker(worker);
                return true;
            }
            else if(worker is null)
            {
                TakeCargoFromWorkerEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Worker)} can't take the cargo from other worker. This worker is null.", false));
                return false;
            }
            else if(worker.TakedCargo is null)
            {
                TakeCargoFromWorkerEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Worker)} can't take the cargo from other {nameof(Worker)}. Other worker doesn't have it.", false));
                return false;
            }
            else if(TakedCargo is not null)
            {
                TakeCargoFromWorkerEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(Worker)} can't take the cargo from other {nameof(Worker)}. He alredy has it.", false));
                return false;
            }
            return false;
        }
    }
}
