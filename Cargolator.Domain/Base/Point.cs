using Cargolator.API.Base.AbstractClasses;
using System;

namespace Cargolator.API.Base
{
    public class Point : Point2D
    {
        public Point() { }
        public Point(int x, int y)
        {
            if (x < 0) throw new ArgumentException("X cannot be a negative number", "X");
            if (y < 0) throw new ArgumentException("Y cannot be a negative number", "Y");
            X = x;
            Y = y;
        }
        public override bool Equals(object obj)
        {
            if (obj is Point && obj is not null)
            {
                var point = obj as Point;
                return this.X.Equals(point.X) && this.Y.Equals(point.Y);
            }
            return false;
        }
        public override string ToString()
        {
            return $"({X}; {Y})";
        }
    }
}
