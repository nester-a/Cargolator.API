using Cargolator.API.Base;
using Xunit;

namespace Cargolator.Tests.EntitysTests
{
    public class PointTests
    {
        [Fact]
        public void PointEqualsResult()
        {
            // Arrange
            Point a = new Point(5, 5);
            Point b = new Point(5, 5);

            // Act
            bool result = a.Equals(b);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PointUnequalsResult()
        {
            // Arrange
            Point a = new Point(5, 5);
            Point b = new Point(6, 6);

            // Act
            bool result = a.Equals(b);

            // Assert
            Assert.True(!result);
        }
    }
}
