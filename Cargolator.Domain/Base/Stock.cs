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
    public class Stock : IStock
    {
        public delegate void StockHandler(object sender, StockEventArgs e);
        public event StockHandler StockEvent;

        public Queue<Cargo> CargosStock { get; private set; } = new Queue<Cargo>();

        public void AddCargo(Cargo cargo)
        {
            if (cargo is null) throw new ArgumentNullException("Cargo", "Cargo is null");
            if (cargo.Status != CargoStatus.OnStock) cargo.ChangeStatus(CargoStatus.OnStock);
            CargosStock.Enqueue(cargo);
            StockEvent?.Invoke(this, new StockEventArgs($"The cargo {cargo.Id} succesfully added on stock", true));
        }

        public void AddRangeCargo(params Cargo[] cargos)
        {
            if (cargos is null) throw new ArgumentNullException("Cargos", "Cargos is null");
            for (int i = 0; i < cargos.Length; i++)
            {
                AddCargo(cargos[i]);
            }
            StockEvent?.Invoke(this, new StockEventArgs($"The cargos succesfully added on stock", true));
        }

        public void AddRangeCargo(ICollection<Cargo> cargos)
        {
            if (cargos is null) throw new ArgumentNullException("Cargos", "Cargos is null");
            foreach (var cargo in cargos)
            {
                AddCargo(cargo);
            }
            StockEvent?.Invoke(this, new StockEventArgs($"The cargos succesfully added on stock", true));
        }

        public bool Contains(Cargo cargo)
        {
            if (cargo is null) throw new ArgumentNullException("Cargo", "Cargo is null");
            if (GetCount() == 0) throw new InvalidOperationException("Stock is empty");
            return CargosStock.Contains(cargo);
        }

        public int GetCount()
        {
            return CargosStock.Count;
        }

        public Cargo RemoveCargo()
        {
            if (GetCount() == 0) throw new InvalidOperationException("Stock is empty");
            var dequeued = CargosStock.Dequeue();
            StockEvent?.Invoke(this, new StockEventArgs($"The cargo {dequeued.Id} succesfully ejected from stock", true));
            return dequeued;
        }

        public bool TryRemoveCargo(out Cargo cargo)
        {
            cargo = null;
            if (GetCount() <= 0)
            {
                StockEvent?.Invoke(this, new StockEventArgs($"Stock is empty", false));
                return false;
            }
            cargo = RemoveCargo();
            return true;
        }
    }
}
