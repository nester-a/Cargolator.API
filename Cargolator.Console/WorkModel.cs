using Cargolator.API.Base;
using Cargolator.API.Base.Interfaces;
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
        Cargo cargo1 = new Cargo { Id = 1, Length = 4, Width = 2 };
        Cargo cargo2 = new Cargo { Id = 2, Length = 1, Width = 2 };
        Cargo cargo3 = new Cargo { Id = 3, Length = 5, Width = 2 };
        Cargo cargo4 = new Cargo { Id = 4, Length = 2, Width = 2 };
        
        public void StartWork()
        {
            Coordinates lc = null;
            stock.AddRangeOnStock(cargo1, cargo3, cargo4, cargo2);

            for (int i = 0; i < 4; i++)
            {
                if (loader.TryTakeFromStock(stock))
                {
                    lc = supervisor.FindLoadPlace(loader.TakedCargo);
                    if (lc != null)
                    {
                        supervisor.LoadList.Add(loader.TakedCargo.Id, lc);
                        loader.TryLoad(container);
                        SomeHelp();
                        System.Console.ReadLine();
                        System.Console.WriteLine();
                    }
                }

            }

            for (int i = 0; i < 4; i++)
            {
                if (unloader.TryUnload(container))
                {
                    supervisor.EraceCargoFromMap(unloader.TakedCargo);
                    unloader.PlaceToStock(stock);
                }
                SomeHelp();
                System.Console.ReadLine();
                System.Console.WriteLine();
            }
        }
        private void SomeHelp()
        {
            for (int i = 0; i < supervisor.ContainerMap.GetLength(0); i++)
            {
                for (int j = 0; j < supervisor.ContainerMap.GetLength(1); j++)
                {
                    if (supervisor.ContainerMap[i, j] is null)
                    {
                        System.Console.Write("|_|");
                    }
                    else
                        System.Console.Write($"|{supervisor.ContainerMap[i, j]}|");
                }
                System.Console.WriteLine();
            }
        }
    }
    public class WorkModel2
    {
        private void SomeHelp()
        {
            for (int i = 0; i < sv.ContainerMap.GetLength(0); i++)
            {
                for (int j = 0; j < sv.ContainerMap.GetLength(1); j++)
                {
                    if (sv.ContainerMap[i, j] is null)
                    {
                        System.Console.Write("|_|");
                    }
                    else System.Console.Write($"|{sv.ContainerMap[i, j]}|");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }

        Stock stock = new Stock();
        Unloader unloader = new Unloader();
        static Container cnt = new Container() { Length = 10, Width = 10 };
        Supervisor sv = new Supervisor(cnt);
        List<Cargo> crgs = new List<Cargo>()
            {
                new Cargo() { Length = 3, Width = 3, Id = 1 },
                new Cargo() { Length = 2, Width = 4, Id = 2 },
                new Cargo() { Length = 3, Width = 3, Id = 3 },
                new Cargo() { Length = 5, Width = 6, Id = 4 },
                new Cargo() { Length = 1, Width = 4, Id = 5 },
                new Cargo() { Length = 2, Width = 2, Id = 6 },
                new Cargo() { Length = 2, Width = 2, Id = 7 },
                new Cargo() { Length = 2, Width = 2, Id = 8 },
                new Cargo() { Length = 2, Width = 2, Id = 9 },

            };
        List<bool> results = new List<bool>();
        public void StartWork()
        {
            for (int i = 0; i < crgs.Count; i++)
            {
                var coor = sv.FindPlace(crgs[i]);
                if (coor is null) results.Add(false);
                else results.Add(true);
                SomeHelp();
            }
            System.Console.ReadLine();
            for (int i = 0; i < crgs.Count; i++)
            {
                if (unloader.TryUnload(cnt))
                {
                    sv.EraceCargoFromMap(unloader.TakedCargo);
                    unloader.PlaceToStock(stock);
                }
                SomeHelp();
                System.Console.ReadLine();
            }
        }
    }
}
