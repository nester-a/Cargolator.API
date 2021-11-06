using Cargolator.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests
{
    public class WorkProcessTests
    {
        [Fact]
        public void LoadRandomCargoFromStockTest()
        {
            // **Arrange**
            Random rnd = new Random();
            Container cnt = new Container() { Length = 12, Width = 3 };
            Stock stck = new Stock();
            List<Cargo> crgs = new List<Cargo>();
            Loader ldr = new Loader();
            Unloader unldr = new Unloader();
            Supervisor sv = new Supervisor(cnt);

            // **Act**

            // Random cargo creating
            for (int i = 0; i < 10; i++)
            {
                crgs.Add(new Cargo() { Id = i, Length = rnd.Next(1, 4), Width = rnd.Next(1, 4) });
            }

            // Cargo sort
            crgs.Sort((o, e) => (e.Length * e.Width).CompareTo(o.Width * o.Length));

            // Add cargos to stock
            stck.AddRangeOnStock(crgs);

            // Start work
            for (int i = 0; i < crgs.Count; i++)
            {
                if (ldr.TryTakeFromStock(stck))
                {
                    Coordinates coor = sv.FindPlace(ldr.TakedCargo);
                    if (coor is not null)
                    {
                        sv.LoadList.Add(ldr.TakedCargo.Id, coor);
                        ldr.TryLoad(cnt);
                    }
                    else
                    {
                        if (ldr.TryRotate())
                        {
                            Coordinates coor2 = sv.FindPlace(ldr.TakedCargo);
                            if (coor is not null)
                            {
                                sv.LoadList.Add(ldr.TakedCargo.Id, coor2);
                                ldr.TryLoad(cnt);
                            }
                            else break;
                        }

                    }
                }
            }

            // **Asserts**
        }
    }
}
