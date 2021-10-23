using Cargolator.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests
{
    public class PointTests
    {
        [Fact]
        public void PointEqualsResult()
        {
            // Arrange
            Point a = new Point() { X=5, Y=5};
            Point b = new Point() { X=5, Y=5};

            // Act
            bool result = a.Equals(b);

            // Assert
            Assert.True(result);
        }
    }
}
