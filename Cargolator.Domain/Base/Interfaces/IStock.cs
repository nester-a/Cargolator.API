﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base.Interfaces
{
    public interface IStock
    {
        Queue<ICargo> CargosStock { get; set; }
        void AddOnStock(params ICargo[] cargos);
    }
}