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
        public Queue<Cargo> CargosStock { get; private set; } = new Queue<Cargo>();

        public void AddCargo(Cargo cargo)
        {
            if (cargo.Status != CargoStatus.OnStock) cargo.ChangeStatus(CargoStatus.OnStock);
            CargosStock.Enqueue(cargo);
        }

        public void AddRangeCargo(params Cargo[] cargos)
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

        public bool Contains(Cargo cargo)
        {
            return CargosStock.Contains(cargo);
        }

        public int GetCount()
        {
            return CargosStock.Count;
        }

        public Cargo RemoveCargo()
        {
            return CargosStock.Dequeue();
        }

        public bool TryRemoveCargo(out Cargo cargo)
        {
            cargo = null;
            if (GetCount() <= 0) return false;
            cargo = RemoveCargo();
            return true;
        }
    }
}
