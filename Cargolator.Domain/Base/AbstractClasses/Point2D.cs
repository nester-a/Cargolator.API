using Cargolator.API.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.AbstractClasses
{
    public abstract class Point2D : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
