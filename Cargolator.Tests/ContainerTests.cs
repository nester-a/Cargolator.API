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
        public void UnloadContainerResutl()
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
    }
}
