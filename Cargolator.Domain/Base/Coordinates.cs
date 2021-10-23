using Cargolator.Domain.Base.AbstractClasses;
using Cargolator.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base
{
    public class Coordinates : Coordinates2D
    {
        public Coordinates(Point2D upperLeftCorner, Point2D lowerRightCorner)
        {
            UpperLeftCorner = upperLeftCorner;
            LowerRightCorner = lowerRightCorner;
        }
        public override bool Equals(object obj)
        {
            if (obj is Coordinates && obj is not null)
            {
                var coor = obj as Coordinates;
                return UpperLeftCorner.Equals(coor.UpperLeftCorner) && LowerRightCorner.Equals(coor.LowerRightCorner);
            }
            return false;
        }
    }
}
