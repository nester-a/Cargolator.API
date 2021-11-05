using Cargolator.API.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base
{
    public class Container : ILoadable
    {
        public Stack<ICargo> LoadedCargo { get; set; } = new Stack<ICargo>();

        public int Length { get; set; }

        public int Width { get; set; }
    }
}
