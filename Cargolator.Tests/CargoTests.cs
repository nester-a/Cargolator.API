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
    public class CargoTests
    {
        [Fact]
        public void EqualsTrueTest()
        {
            // Arrange
            Cargo crg1 = new Cargo(0, 2, 2);
            Cargo crg2 = new Cargo(0, 2, 2);

            // Act
            // Assert
            Assert.Equal<Cargo>(crg1, crg2);
        }
        [Fact]
        public void EqualsFalseTest()
        {
            // Arrange
            Cargo crg1 = new Cargo(0, 2, 2);
            Cargo crg2 = new Cargo(1, 3, 3);

            // Act
            bool result = crg1.Equals(crg2);

            // Assert
            Assert.True(!result);
        }
        [Fact]
        public void CargoEqualsWorkerFalseTest()
        {
            // Arrange
            Cargo crg1 = new Cargo(0, 2, 2);
            Worker wrk = new Loader();

            // Act
            bool result = crg1.Equals(wrk);

            // Assert
            Assert.True(!result);
        }
    }
}
