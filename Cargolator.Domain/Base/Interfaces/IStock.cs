using System.Collections.Generic;

namespace Cargolator.API.Base.Interfaces
{
    public interface IStock : IAddCargo, IRemoveCargo, IGetCount, IContains
    {
        Queue<Cargo> CargosStock { get; }
    }
}
