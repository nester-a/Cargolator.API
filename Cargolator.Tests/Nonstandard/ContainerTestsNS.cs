using Cargolator.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests
{
    public class ContainerTestsNS
    {
        [Fact]
        public void LoadContainerResult()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo(0, 4, 2);
            Loader ldr = new Loader();

            // Act
            Coordinates loadCoordinates = sv.FindPlaceAndLoadOnIt(crg);
            if (loadCoordinates is not null)
            {
                sv.LoadList.Add(crg.Id, loadCoordinates);
                ldr.TryTake(crg);
                if(ldr.TakedCargo is not null)
                {
                    ldr.Load(cnt);
                }
            }

            // Assert
            Assert.True(cnt.Contains(crg));
        }

        [Fact]
        public void UnloadContainerResult()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo(0, 4, 2);
            Loader ldr = new Loader();
            Unloader unldr = new Unloader();

            // Act
            Coordinates loadCoordinates = sv.FindPlaceAndLoadOnIt(crg);
            if (loadCoordinates is not null)
            {
                sv.LoadList.Add(crg.Id, loadCoordinates);
                ldr.TryTake(crg);
                if (ldr.TakedCargo is not null)
                {
                    ldr.Load(cnt);
                }
            }
            if (unldr.TryUnload(cnt))
                sv.EraseCargoFromMap(unldr.TakedCargo);

            // Assert
            Assert.True(!cnt.Contains(crg));
        }

        [Fact]
        public void LoadUnloadRotateLoadContainerResult()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo(0, 4, 2);
            Loader ldr = new Loader();
            Unloader unldr = new Unloader();
            Stock stck = new Stock();

            // Act
            Coordinates loadCoordinates = sv.FindPlaceAndLoadOnIt(crg);
            if (loadCoordinates is not null)
            {
                sv.LoadList.Add(crg.Id, loadCoordinates);
                ldr.TryTake(crg);
                if (ldr.TakedCargo is not null)
                {
                    ldr.Load(cnt);
                }
            }
            if (unldr.TryUnload(cnt))
                sv.EraseCargoFromMap(unldr.TakedCargo);

            if (unldr.TryPlaceToStock(stck))
            {
                if (ldr.TryTakeFromStock(stck))
                {
                    if (ldr.TryRotate())
                    {
                        sv.LoadList.Add(crg.Id, sv.FindPlaceAndLoadOnIt(ldr.TakedCargo));
                    }
                }
            }

            // Assert
            Assert.True(ldr.TryLoad(cnt));
        }

        [Fact]
        public void LoadFewGoodsResult()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            List<Cargo> crgList = new List<Cargo>() {
                new Cargo(1, 4, 2),
                new Cargo(2, 3, 3),
                new Cargo(3, 5, 5),
            };
            Loader ldr = new Loader();

            // Act
            for (int i = 0; i < 3; i++)
            {
                Coordinates loadCoordinates = sv.FindPlaceAndLoadOnIt(crgList[i]);
                if (loadCoordinates is not null)
                {
                    sv.LoadList.Add(crgList[i].Id, loadCoordinates);
                    ldr.TryTake(crgList[i]);
                    if (ldr.TakedCargo is not null)
                    {
                        ldr.Load(cnt);
                    }
                }
            }
            // Assert
            bool ContainAllGoods()
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!cnt.Contains(crgList[i])) return false;
                }
                return true;
            }
            Assert.True(ContainAllGoods());
        }
    }
}
