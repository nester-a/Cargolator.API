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
        public ICargo TakedCargo { get; protected set; }
        public void Take(ICargo cargo)
        {
            TakedCargo = cargo;
        }
        public bool TryTake(ICargo cargo)
        {
            if (TakedCargo is null)
            {
                Take(cargo);
                return true;
            }
            return false;
        }
        public bool PlaceToStock(IStock stock)
        {
            if(TakedCargo is not null)
            {
                stock.CargosStock.Enqueue(TakedCargo);
                TakedCargo = null;
                return true;
            }
            return false;
        }

        public void TakeFromStock(IStock stock)
        {
            TakedCargo = stock.CargosStock.Dequeue();
        }

        public bool TryTakeFromStock(IStock stock)
        {
            if (TakedCargo is null)
            {
                TakeFromStock(stock);
                return true;
            }
            return false;
        }
    }
}
