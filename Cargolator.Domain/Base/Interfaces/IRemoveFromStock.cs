using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.Interfaces
{
    public interface IRemoveFromStock
    {

        ICargo RemoveFromStock();
        bool TryRemoveFromStock(out ICargo cargo);
    }
}
