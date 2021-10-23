using Cargolator.Domain.Base.AbstractClasses;
using Cargolator.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base
{
    public class Point : Point2D
    {
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
