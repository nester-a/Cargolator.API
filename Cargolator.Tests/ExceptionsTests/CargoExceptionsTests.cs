using Cargolator.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests.ExceptionsTests
{
    public class CargoExceptionsTests
    {
        [Fact]
        public void CargoConstructorLenghtArgumentExceptionTest()
        {
            // Arrange
            bool catched = false;

            // Act
            try
            {
                Cargo crg = new Cargo(0, 0, 1);
            }
            catch (ArgumentException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }
        [Fact]
        public void CargoConstructorWidthArgumentExceptionTest()
        {
            // Arrange
            bool catched = false;

            // Act
            try
            {
                Cargo crg = new Cargo(0, 1, 0);
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
