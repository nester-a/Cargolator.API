using Cargolator.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base
{
    public class Point : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
