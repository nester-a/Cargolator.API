using Cargolator.API.Base;
using Cargolator.API.Base.AbstractClasses;
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
        public void TakeTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 2, 2);

            // Act
            wrk.Take(crg);

            bool result = wrk.TakedCargo is not null && ReferenceEquals(wrk.TakedCargo, crg);

            // Assert
            Assert.True(result);
        }
    }
}
