using Cargolator.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base
{
    public class Cargo : ICargo
    {
        public int Id { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }
    }
}
