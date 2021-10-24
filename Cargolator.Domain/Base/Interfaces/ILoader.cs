﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base.Interfaces
{
    public interface ILoader : ITakeCargo
    {
        void Load(ILoadable container);
        bool TryLoad(ILoadable container);
        void Rotate();
        void TakeFromStock(IStock stock);
        bool TryTakeFromStock(IStock stock);
    }
}
