﻿using Cargolator.API.Base.Enums;
using Cargolator.API.Base.EventArgs;
using Cargolator.API.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.AbstractClasses
{
    public abstract class Worker : ITakeFromWorker
    {
        public delegate void WorkerHandler(object sender, WorkerEventArgs e);
        public event WorkerHandler TakeCargoEvent;
        public event WorkerHandler DropCargoEvent;
        public WorkerType ThisWorkerType { get; protected set; }
        public Cargo TakedCargo { get; private set; }
        public void Take(Cargo cargo)
        {
            if (cargo is null) throw new ArgumentNullException("Cargo", "Cargo parameter is null");
            if (cargo.Status == CargoStatus.OnHands) throw new ArgumentException("Cargo has wrong status", $"Cargo #{cargo.Id}");
            TakedCargo = cargo;
            TakedCargo.ChangeStatus(CargoStatus.OnHands);
            TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} successfully took the cargo {cargo.Id}", true));
        }
        public bool TryTake(Cargo cargo)
        {
            if (TakedCargo is null && cargo is not null && cargo.Status != CargoStatus.OnHands)
            {
                Take(cargo);
                return true;
            }
            TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} cannot take the cargo {cargo.Id}. He has already taken the cargo {TakedCargo.Id}", false));
            return false;
        }
        public void DropCargo()
        {
            if (TakedCargo is null) throw new NullReferenceException($"This {nameof(ThisWorkerType)} taked cargo is null");
            TakedCargo.ChangeStatus(CargoStatus.Wait);
            TakedCargo = null;
            DropCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} successfully drop his cargo.", true));
        }
        public void DropCargo(CargoStatus dropedCargoStatus)
        {
            if (TakedCargo is null) throw new NullReferenceException($"This {nameof(ThisWorkerType)} taked cargo is null");
            if (dropedCargoStatus == CargoStatus.OnHands) throw new ArgumentException("Droped cargo status cannot be OnHands");
            TakedCargo.ChangeStatus(dropedCargoStatus);
            TakedCargo = null;
            DropCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} successfully drop his cargo.", true));
        }
        public bool TryDropCargo()
        {
            if (TakedCargo is not null)
            {
                DropCargo();
                return true;
            }
            DropCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} cannot drop his cargo. He doesn't have it.", false));
            return false;
        }
        public bool TryDropCargo(CargoStatus dropedCargoStatus)
        {
            if (TakedCargo is not null && dropedCargoStatus != CargoStatus.OnHands)
            {
                DropCargo(dropedCargoStatus);
                return true;
            }
            DropCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} cannot drop his cargo. He doesn't have it.", false));
            return false;
        }
        public void TakeFromWorker(ITakeFromWorker worker)
        {
            if (worker is null) throw new ArgumentNullException("Worker","Worker parameter is null");
            if (TakedCargo is null) throw new NullReferenceException($"This {nameof(ThisWorkerType)} taked cargo is null");
            worker.TakedCargo.ChangeStatus(CargoStatus.Wait);
            TryTake(worker.TakedCargo);
            worker.TryDropCargo();
            TakedCargo.ChangeStatus(CargoStatus.OnHands);
            TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} successfully took the cargo {TakedCargo.Id} from other worker ({nameof(worker.ThisWorkerType)})", true));
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
                TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} can't take the cargo from other worker. This worker is null.", false));
                return false;
            }
            else if(worker.TakedCargo is null)
            {
                TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} can't take the cargo from other worker {nameof(worker.ThisWorkerType)}. Other worker doesn't have it.", false));
                return false;
            }
            else if(TakedCargo is not null)
            {
                TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The {nameof(ThisWorkerType)} can't take the cargo from other worker {nameof(worker.ThisWorkerType)}. He alredy has it.", false));
                return false;
            }
            return false;
        }
    }
}
