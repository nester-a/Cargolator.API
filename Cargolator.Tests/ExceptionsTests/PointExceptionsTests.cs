using Cargolator.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests.ExceptionsTests
{
    public class PointExceptionsTests
    {
        [Fact]
        public void PointConstructorXArgumentExceptionTest()
        {
            // Arrange

            bool catched = false;

            // Act

            try
            {
                Point p = new Point(-1, 0);
            }
            catch (ArgumentException e)
            {
                if (e is not null) catched = true;
            }

            // Assert

            Assert.True(catched);
        }

        [Fact]
        public void PointConstructorYArgumentExceptionTest()
        {
            // Arrange

            bool catched = false;

            // Act

            try
            {
                Point p = new Point(0, -1);
            }
            catch (ArgumentException e)
            {
                if (e is not null) catched = true;
            }

            // Assert

            Assert.True(catched);
        }
    }
}
