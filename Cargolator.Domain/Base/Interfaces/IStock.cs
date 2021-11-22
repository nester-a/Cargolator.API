using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.Interfaces
{
    public interface IStock : IAddCargo, IRemoveCargo, IGetCount
    {
        Queue<ICargo> CargosStock { get; }
    }
}
