using Cargolator.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests
{
    public class CoordinatesTests
    {
        [Fact]
        public void CoordinatesEqualsTest()
        {
            // Arrange
            Point a = new Point() { X = 5, Y = 5 };
            Point b = new Point() { X = 6, Y = 6 };
            Point c = new Point() { X = 5, Y = 5 };
            Point d = new Point() { X = 6, Y = 6 };

            Coordinates coor1 = new Coordinates(a, b);
            Coordinates coor2 = new Coordinates(c, d);

            // Act
            bool result = coor1.Equals(coor2);

            // Assert
            Assert.True(result);
        }
    }
}
