using Cargolator.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests.ExceptionsTests
{
    public class CoordinatesExceptionsTests
    {
        [Fact]
        public void CoordinatesConstructorUpperLeftCornerArgumentNullExceptionTest()
        {
            // Arrange
            bool catched = false;

            // Act
            try
            {
                Coordinates crg = new Coordinates(null, new Point(0, 0));
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }

        [Fact]
        public void CoordinatesConstructorLowerRightCornerArgumentNullExceptionTest()
        {
            // Arrange
            bool catched = false;

            // Act
            try
            {
                Coordinates crg = new Coordinates(new Point(0, 0), null);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }
    }
}
