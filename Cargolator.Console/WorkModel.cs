﻿using Cargolator.Domain.Base;
using Cargolator.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Console
{
    public class WorkModel
    {
        Stock stock = new Stock();
        static Container container = new Container { Length = 10, Width = 5 };
        Loader loader = new Loader();
        Unloader unloader = new Unloader();
        Supervisor supervisor = new Supervisor(container);
        Cargo cargo1 = new Cargo { Id = 1, Length = 5, Width = 2 };
        Cargo cargo2 = new Cargo { Id = 2, Length = 5, Width = 2 };
        Cargo cargo3 = new Cargo { Id = 3, Length = 5, Width = 2 };
        Cargo cargo4 = new Cargo { Id = 4, Length = 5, Width = 2 };
        
        public void StartWork()
        {
            stock.AddOnStock(cargo1, cargo3, cargo4, cargo2);
            loader.TryTakeFromStock(stock);
            Coordinates lc = supervisor.FindLoadPlace(loader.TakedCargo);
        }
    }
}