using Cargolator.API.Base.Enums;
using Cargolator.API.Base.EventArgs;
using Cargolator.API.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cargolator.API.Base
{
    public class Container : ILoadable
    {
        public delegate void ContainerHandler(object sender, ContainerEventArgs e);
        public event ContainerHandler ContainerEvent;
        public Stack<Cargo> LoadedCargo { get; private set; } = new Stack<Cargo>();

        public int Length { get; set; }

        public int Width { get; set; }

        public Container(int length, int width)
        {
            if (length == 0) throw new ArgumentException("Container lenght can not be 0", "Length");
            if (width == 0) throw new ArgumentException("Container Width can not be 0", "Width");
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
            ContainerEvent?.Invoke(this, new ContainerEventArgs($"The cargos succesfully added in container", true));
        }

        public void AddCargo(Cargo cargo)
        {
            if (cargo is null) throw new ArgumentNullException("cargos", "Cargos parameter is null");
            if (cargo.Status != CargoStatus.InContainer) cargo.ChangeStatus(CargoStatus.InContainer);
            LoadedCargo.Push(cargo);
            ContainerEvent?.Invoke(this, new ContainerEventArgs($"The cargo {cargo.Id} succesfully added in container", true));
        }

        public void AddRangeCargo(ICollection<Cargo> cargos)
        {
            if (cargos is null) throw new ArgumentNullException("cargos", "Cargos parameter is null");
            foreach (var cargo in cargos)
            {
                AddCargo(cargo);
            }
            ContainerEvent?.Invoke(this, new ContainerEventArgs($"The cargos succesfully added in container", true));
        }

        public Cargo RemoveCargo()
        {
            if (GetCount() == 0) throw new InvalidOperationException("Container is empty");
            var poped = LoadedCargo.Pop();
            ContainerEvent?.Invoke(this, new ContainerEventArgs($"The cargo {poped.Id} succesfully ejected from container", true));
            return poped;
        }

        public bool TryRemoveCargo(out Cargo cargo)
        {
            cargo = null;
            if (GetCount() <= 0)
            {
                ContainerEvent?.Invoke(this, new ContainerEventArgs($"Container is empty", false));
                return false;
            }
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
