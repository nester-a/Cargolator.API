using Cargolator.API.Base.Interfaces;

namespace Cargolator.API.Base.AbstractClasses
{
    public abstract class Point2D : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
