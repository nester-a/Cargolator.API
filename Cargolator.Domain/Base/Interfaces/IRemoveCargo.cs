using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.Interfaces
{
    public interface IRemoveCargo
    {

        ICargo RemoveCargo();
        bool TryRemoveCargo(out ICargo cargo);
    }
}
