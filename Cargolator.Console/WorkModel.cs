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
        static Container container = new Container ( 10, 5 );
        Loader loader = new Loader();
        Unloader unloader = new Unloader();
        Supervisor supervisor = new Supervisor(container);
        Cargo cargo1 = new Cargo (1, 4, 2);
        Cargo cargo2 = new Cargo (2, 1, 2);
        Cargo cargo3 = new Cargo (3, 5, 2);
        Cargo cargo4 = new Cargo (4, 2, 2);
        
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
        static Container cnt = new Container(10, 10);
        Supervisor sv = new Supervisor(cnt);
        List<Cargo> crgs = new List<Cargo>()
            {
                new Cargo(1, 3, 3),
                new Cargo(2, 2, 4),
                new Cargo(3, 3, 3),
                new Cargo(4, 5, 6),
                new Cargo(5, 1, 4),
                new Cargo(6, 2, 2),
                new Cargo(7, 2, 2),
                new Cargo(8, 2, 2),
                new Cargo(9, 2, 2),

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
