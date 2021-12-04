using Cargolator.API.Base.Interfaces;

namespace Cargolator.API.Base.AbstractClasses
{
    public abstract class Coordinates2D : ICoordinates
    {
        public IPoint UpperLeftCorner { get; set; }
        public IPoint LowerRightCorner { get; set; }
    }
}
