﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.Interfaces
{
    public interface ILoadable : ISizeable, IGetCount
    {
        Stack<ICargo> LoadedCargo { get; }
    }
}
