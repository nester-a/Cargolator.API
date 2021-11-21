using Cargolator.API.Base.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.Interfaces
{
    public interface ISupervisor
    {
        string[,] ContainerMap { get; set; }
        Dictionary<int, ICoordinates> LoadList { get; set; }
        Coordinates FindPlaceAndLoadOnIt(ICargo cargoForLoad);
    }
}
