using Cargolator.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests
{
    public class ContainerExceptionsTests
    {
        [Fact]
        public void AddCargoArgumentNullExceptionTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo crg = null;

            bool catched = false;

            // Act
            try
            {
                cnt.AddCargo(crg);
            }
            catch(ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }

        [Fact]
        public void AddRangeArrayParamArgumentNullExceptionTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo[] crgs = null;

            bool catched = false;

            // Act
            try
            {
                cnt.AddRangeCargo(crgs);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }

        [Fact]
        public void AddRangeCollectionParamArgumentNullExceptionTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            List<Cargo> crgs = null;

            bool catched = false;

            // Act
            try
            {
                cnt.AddRangeCargo(crgs);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }

        [Fact]
        public void ContainsArgumentNullExceptionTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo crg = new Cargo(0, 1, 1);
            Cargo crg2 = null;
            bool catched = false;


            // Act
            cnt.AddCargo(crg);

            try
            {
                cnt.Contains(crg2);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }

        [Fact]
        public void RemoveCargoInvalidOperationExceptionTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            bool catched = false;

            // Act
            try
            {
                cnt.RemoveCargo();
            }
            catch (InvalidOperationException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }

        [Fact]
        public void ContainerConstructorLenghtArgumentExceptionTest()
        {
            // Arrange
            bool catched = false;

            // Act
            try
            {
                Container crg = new Container(0, 1);
            }
            catch (ArgumentException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }

        [Fact]
        public void ContainerConstructorWidthArgumentExceptionTest()
        {
            // Arrange
            bool catched = false;

            // Act
            try
            {
                Container crg = new Container(1, 0);
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
