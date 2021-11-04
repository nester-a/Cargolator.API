using Cargolator.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests
{
    public class ContainerTests
    {
        [Fact]
        public void LoadContainerResult()
        {
            // Arrange
            Container cnt = new Container() { Length = 10, Width = 10 };
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo() { Length = 4, Width = 2 };
            Loader ldr = new Loader();

            // Act
            Coordinates loadCoordinates = sv.FindLoadPlace(crg);
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
            Assert.True(cnt.LoadedCargo.Contains(crg));
        }

        [Fact]
        public void UnloadContainerResult()
        {
            // Arrange
            Container cnt = new Container() { Length = 10, Width = 10 };
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo() { Length = 4, Width = 2 };
            Loader ldr = new Loader();
            Unloader unldr = new Unloader();

            // Act
            Coordinates loadCoordinates = sv.FindLoadPlace(crg);
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
                sv.EraceCargoFromMap(unldr.TakedCargo);

            // Assert
            Assert.True(!cnt.LoadedCargo.Contains(crg));
        }

        [Fact]
        public void LoadUnloadRotateLoadContainerResult()
        {
            // Arrange
            Container cnt = new Container() { Length = 10, Width = 10 };
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo() { Length = 4, Width = 2 };
            Loader ldr = new Loader();
            Unloader unldr = new Unloader();
            Stock stck = new Stock();

            // Act
            Coordinates loadCoordinates = sv.FindLoadPlace(crg);
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
                sv.EraceCargoFromMap(unldr.TakedCargo);

            if (unldr.TryPlaceToStock(stck))
            {
                if (ldr.TryTakeFromStock(stck))
                {
                    if (ldr.TryRotate())
                    {
                        sv.LoadList.Add(crg.Id, sv.FindLoadPlace(ldr.TakedCargo));
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
            Container cnt = new Container() { Length = 10, Width = 10 };
            Supervisor sv = new Supervisor(cnt);
            List<Cargo> crgList = new List<Cargo>() {
                new Cargo() { Id = 1, Length = 4, Width = 2 },
                new Cargo() { Id = 2, Length = 3, Width = 3 },
                new Cargo() { Id = 3, Length = 5, Width = 5 },
            };
            Loader ldr = new Loader();

            // Act
            for (int i = 0; i < 3; i++)
            {
                Coordinates loadCoordinates = sv.FindLoadPlace(crgList[i]);
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
                    if (!cnt.LoadedCargo.Contains(crgList[i])) return false;
                }
                return true;
            }
            Assert.True(ContainAllGoods());
        }
    }
}
