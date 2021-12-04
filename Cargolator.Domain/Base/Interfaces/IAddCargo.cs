using System.Collections.Generic;

namespace Cargolator.API.Base.Interfaces
{
    public interface IAddCargo
    {
        void AddRangeCargo(params Cargo[] cargos);
        void AddCargo(Cargo cargo);
        void AddRangeCargo(ICollection<Cargo> cargos);
    }
}
