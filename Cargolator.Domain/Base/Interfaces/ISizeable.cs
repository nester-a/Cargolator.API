﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base.Interfaces
{
    public interface ISizeable
    {
        int Length { get; set; }
        int Width { get; set; }
    }
}