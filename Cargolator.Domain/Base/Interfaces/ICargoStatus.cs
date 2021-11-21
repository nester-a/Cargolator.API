using Cargolator.API.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.Interfaces
{
    public interface ICargoStatus
    {
        CargoStatus Status { get; }
        void ChangeStatus(CargoStatus newStatus);
    }
}
