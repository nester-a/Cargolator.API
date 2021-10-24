using Cargolator.Domain.Base.EventArgs;
using Cargolator.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base.AbstractClasses
{
    public abstract class Worker : ITakeCargo
    {
        public delegate void WorkerHandler(object sender, WorkerEventArgs e);
        public event WorkerHandler TakeCargoEvent;
        public ICargo TakedCargo { get; protected set; }
        public void Take(ICargo cargo)
        {
            TakedCargo = cargo;
            TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The worker successfully took the cargo {cargo.Id}", true));
        }
        public bool TryTake(ICargo cargo)
        {
            if (TakedCargo is null)
            {
                Take(cargo);
                return true;
            }
            TakeCargoEvent?.Invoke(this, new WorkerEventArgs($"The worker cannot take the cargo {cargo.Id}. He has already taken the cargo {TakedCargo.Id}", false));
            return false;
        }

    }
}
