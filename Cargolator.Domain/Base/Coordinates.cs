using Cargolator.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base
{
    public class Coordinates : ICoordinates
    {
        public IPoint UpperLeftCorner { get; set; }
        public IPoint LowerRightCorner { get; set; }
        public Coordinates(IPoint upperLeftCorner, IPoint lowerRightCorner)
        {
            UpperLeftCorner = upperLeftCorner;
            LowerRightCorner = lowerRightCorner;
        }
    }
}
