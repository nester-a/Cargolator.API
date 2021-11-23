using Cargolator.API.Base.Enums;
using Cargolator.API.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base
{
    public class Container : ILoadable
    {
        public Stack<Cargo> LoadedCargo { get; private set; } = new Stack<Cargo>();

        public int Length { get; set; }

        public int Width { get; set; }

        public Container(int length, int width)
        {
            Length = length;
            Width = width;
        }

        public int GetCount()
        {
            return LoadedCargo.Count();
        }

        public void AddRangeCargo(params Cargo[] cargos)
        {
            if (cargos is null) throw new ArgumentNullException("cargos", "Cargos parameter is null");
            for (int i = 0; i < cargos.Length; i++)
            {
                AddCargo(cargos[i]);
            }
        }

        public void AddCargo(Cargo cargo)
        {
            if (cargo is null) throw new ArgumentNullException("cargos", "Cargos parameter is null");
            if (cargo.Status != CargoStatus.InContainer) cargo.ChangeStatus(CargoStatus.InContainer);
            LoadedCargo.Push(cargo);
        }

        public void AddRangeCargo(ICollection<Cargo> cargos)
        {
            if (cargos is null) throw new ArgumentNullException("cargos", "Cargos parameter is null");
            foreach (var cargo in cargos)
            {
                AddCargo(cargo);
            }
        }

        public Cargo RemoveCargo()
        {
            if (GetCount() == 0) throw new InvalidOperationException("Container is empty");
            return LoadedCargo.Pop();
        }

        public bool TryRemoveCargo(out Cargo cargo)
        {
            cargo = null;
            if (GetCount() <= 0) return false;
            cargo = RemoveCargo();
            return true;
        }

        public bool Contains(Cargo cargo)
        {
            if (cargo is null) throw new ArgumentNullException("Cargo", "Cargo is null");
            return LoadedCargo.Contains(cargo);
        }
    }
}
