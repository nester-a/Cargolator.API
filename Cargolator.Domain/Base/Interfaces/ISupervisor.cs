using System.Collections.Generic;

namespace Cargolator.API.Base.Interfaces
{
    public interface ISupervisor
    {
        string[,] ContainerMap { get; set; }
        Dictionary<int, ICoordinates> LoadList { get; set; }
        Coordinates FindPlaceAndLoadOnIt(ICargo cargoForLoad);
    }
}
