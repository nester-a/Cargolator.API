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

        public void AddCargo(ICargo cargo)
        {
            if (cargo.Status != CargoStatus.OnStock) cargo.ChangeStatus(CargoStatus.OnStock);
            CargosStock.Enqueue(cargo);
        }

        public void AddRangeCargo(params ICargo[] cargos)
        {
            for (int i = 0; i < cargos.Length; i++)
            {
                AddCargo(cargos[i]);
            }
        }

        public void AddRangeCargo(ICollection<Cargo> cargos)
        {
            foreach (var cargo in cargos)
            {
                AddCargo(cargo);
            }
        }

        public int GetCount()
        {
            return CargosStock.Count;
        }

        public ICargo RemoveCargo()
        {
            return CargosStock.Dequeue();
        }

        public bool TryRemoveCargo(out ICargo cargo)
        {
            cargo = null;
            if (GetCount() <= 0) return false;
            cargo = RemoveCargo();
            return true;
        }
    }
}
