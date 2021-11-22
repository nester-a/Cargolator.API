using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.Interfaces
{
    public interface IAddOnStock
    {
        void AddRangeOnStock(params ICargo[] cargos);
        void AddOnStock(ICargo cargo);
        void AddRangeOnStock(ICollection<Cargo> cargos);
    }
}
