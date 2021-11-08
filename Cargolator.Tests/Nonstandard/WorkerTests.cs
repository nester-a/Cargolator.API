using Cargolator.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests
{
    public class WorkerTests
    {
        [Fact]
        public void CargoFromOneWorkerToAnotherWorkerTest()
        {
            // Arrange
            Cargo crg = new Cargo(1, 1, 1);
            Loader ldr = new Loader();
            Unloader unldr = new Unloader();

            // Act
            if (ldr.TryTake(crg))
            {
                unldr.TryTakeFromWorker(ldr);
            }

            // Asserts
            Assert.True(ldr.TakedCargo is null && unldr.TakedCargo is not null);
        }
    }
}
