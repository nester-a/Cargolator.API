using Cargolator.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base.AbstractClasses
{
    public abstract class Coordinates2D : ICoordinates
    {
        public IPoint UpperLeftCorner { get; set; }
        public IPoint LowerRightCorner { get; set; }
    }
}
