using Cargolator.API.Base.AbstractClasses;
using Cargolator.API.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base
{
    public class Point : Point2D
    {
        public Point() { }
        public Point(int x, int y)
        {
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
    }
}
