using Cargolator.Domain.Base.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base.Interfaces
{
    public interface ISupervisor
    {
        string[,] ContainerMap { get; set; }
        Dictionary<int, ICoordinates> LoadList { get; set; }
        Coordinates FindLoadPlace(ICargo cargoForLoad);
    }
}
