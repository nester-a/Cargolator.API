using Cargolator.API.Base.Enums;
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
        public Queue<ICargo> CargosStock { get; private set; } = new Queue<ICargo>();

        public void AddOnStock(ICargo cargo)
        {
            if (cargo.Status != CargoStatus.OnStock) cargo.ChangeStatus(CargoStatus.OnStock);
            CargosStock.Enqueue(cargo);
        }

        public void AddRangeOnStock(params ICargo[] cargos)
        {
            for (int i = 0; i < cargos.Length; i++)
            {
                AddOnStock(cargos[i]);
            }
        }

        public void AddRangeOnStock(ICollection<Cargo> cargos)
        {
            foreach (var cargo in cargos)
            {
                AddOnStock(cargo);
            }
        }

        public int GetCount()
        {
            return CargosStock.Count;
        }

        public ICargo RemoveFromStock()
        {
            return CargosStock.Dequeue();
        }

        public bool TryRemoveFromStock(out ICargo cargo)
        {
            cargo = null;
            if (CargosStock.Count <= 0) return false;
            cargo = CargosStock.Dequeue();
            return true;
        }
    }
}
