using Cargolator.Domain.Base;
using System;
using Xunit;

namespace Cargolator.Tests
{
    public class SupervisorTests
    {
        [Fact]
        public void FindLoadPlaceResult()
        {
            // Arrange
            Container cnt = new Container() { Length = 10, Width = 10 };
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo() { Length = 5, Width = 2 };

            // Act
            Coordinates result = sv.FindLoadPlace(crg);
            Coordinates expected = new Coordinates(new Point(0, 0), new Point(1, 4));
            var actual = result.Equals(expected);

            // Assert
            Assert.True(actual);
        }
    }
}
