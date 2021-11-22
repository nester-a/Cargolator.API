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
        public Stack<ICargo> LoadedCargo { get; private set; } = new Stack<ICargo>();

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

        public void AddRangeCargo(params ICargo[] cargos)
        {
            for (int i = 0; i < cargos.Length; i++)
            {
                AddCargo(cargos[i]);
            }
        }

        public void AddCargo(ICargo cargo)
        {
            LoadedCargo.Push(cargo);
        }

        public void AddRangeCargo(ICollection<Cargo> cargos)
        {
            foreach (var cargo in cargos)
            {
                AddCargo(cargo);
            }
        }

        public ICargo RemoveCargo()
        {
            return LoadedCargo.Pop();
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
