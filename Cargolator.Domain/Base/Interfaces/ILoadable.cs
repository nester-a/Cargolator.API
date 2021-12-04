using System.Collections.Generic;

namespace Cargolator.API.Base.Interfaces
{
    public interface ILoadable : ISizeable, IGetCount, IAddCargo, IRemoveCargo, IContains
    {
        Stack<Cargo> LoadedCargo { get; }
    }
}
