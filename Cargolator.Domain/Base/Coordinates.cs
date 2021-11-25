using Cargolator.API.Base.AbstractClasses;
using Cargolator.API.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base
{
    public class Coordinates : Coordinates2D
    {
        public Coordinates(Point2D upperLeftCorner, Point2D lowerRightCorner)
        {
            if (upperLeftCorner is null) throw new ArgumentNullException("UpperLeftCorner", "UpperLeftCorner can not be null");
            if (lowerRightCorner is null) throw new ArgumentNullException("LowerRightCorner", "LowerRightCorner can not be null");
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
