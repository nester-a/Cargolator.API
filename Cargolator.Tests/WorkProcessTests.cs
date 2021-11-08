using Cargolator.API.Base;
using Cargolator.API.Base.Interfaces;
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
            Container cnt = new Container(12, 3);
            Stock stck = new Stock();
            List<Cargo> crgs = new List<Cargo>();
            Loader ldr = new Loader();
            Supervisor sv = new Supervisor(cnt);
            Unloader unldr = new Unloader();
            int tryCount = 0;
            Dictionary<int, string> logger = new Dictionary<int, string>();

            // **Act**

            // Random cargo creating
            for (int i = 0; i < 10; i++)
            {
                crgs.Add(new Cargo(i, rnd.Next(1, 4), rnd.Next(1, 4)));
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
                        tryCount = 0;
                    }
                    else
                    {
                        if (ldr.TryRotate())
                        {
                            Coordinates coor2 = sv.FindPlace(ldr.TakedCargo);
                            if (coor2 is not null)
                            {
                                sv.LoadList.Add(ldr.TakedCargo.Id, coor2);
                                ldr.TryLoad(cnt);
                                tryCount = 0;
                            }
                            else
                            {
                                tryCount++;
                                if (unldr.TryTakeFromWorker(ldr))
                                {
                                    if (unldr.TryPlaceToStock(stck))
                                    {
                                        if (tryCount == stck.CargosStock.Count)
                                        {
                                            unldr.TryTakeFromWorker(ldr);
                                            unldr.TryPlaceToStock(stck);
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }


            // **Asserts**
            bool ContainerContainsCargo()
            {
                foreach (var cargo in cnt.LoadedCargo)
                {
                    if (!sv.LoadList.ContainsKey(cargo.Id))
                    {
                        return false;
                    }
                }
                return true;
            }
            
            bool AllCargoOnItsPlace()
            {
                foreach (var cargo in sv.LoadList)
                {
                    if(!CheckHelper(cargo.Key, cargo.Value))
                    {
                        return false;
                    }
                }
                return true;
            }

            bool CheckHelper(int id, ICoordinates coor)
            {
                for (int i = coor.UpperLeftCorner.Y; i < coor.LowerRightCorner.Y; i++)
                {
                    for (int j = coor.UpperLeftCorner.X; j < coor.LowerRightCorner.X; j++)
                    {
                        if(sv.ContainerMap[i,j] != id.ToString())
                        {
                            logger.Add(id, "Груза нет");
                            return false;
                        }
                    }
                }
                logger.Add(id, "Груз есть");
                return true;
            }

            Assert.True(ContainerContainsCargo() && AllCargoOnItsPlace());
        }
    }
}
