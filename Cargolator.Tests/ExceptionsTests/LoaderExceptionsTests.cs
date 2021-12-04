using Cargolator.API.Base;
using System;
using Xunit;

namespace Cargolator.Tests.ExceptionsTests
{
    public class LoaderExceptionsTests
    {
        [Fact]
        public void LoadContainerArgumentNullExceptionTest()
        {
            // Arrange
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 1, 1);

            bool catched = false;

            // Act

            ldr.Take(crg);

            try
            {
                ldr.Load(null);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert

            Assert.True(catched);
        }

        [Fact]
        public void LoadTakedCargoNullReferenceExceptionsTest()
        {
            // Arrange
            Loader ldr = new Loader();
            Container cnt = new Container(5, 5);

            bool catched = false;

            // Act

            try
            {
                ldr.Load(cnt);
            }
            catch (NullReferenceException e)
            {
                if (e is not null) catched = true;
            }

            // Assert

            Assert.True(catched);
        }

        [Fact]
        public void RotateTakedCargoNullReferenceExceptionsTest()
        {
            // Arrange
            Loader ldr = new Loader();

            bool catched = false;

            // Act

            try
            {
                ldr.Rotate();
            }
            catch (NullReferenceException e)
            {
                if (e is not null) catched = true;
            }

            // Assert

            Assert.True(catched);
        }

        [Fact]
        public void TakeFromStockStockArgumentNullExceptionTest()
        {
            // Arrange
            Loader ldr = new Loader();

            bool catched = false;

            // Act

            try
            {
                ldr.TakeFromStock(null);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert

            Assert.True(catched);
        }

        [Fact]
        public void TakeFromStockTakedCargoIsNotNullInvalidOperationExceptionTest()
        {
            // Arrange
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            Stock stck = new Stock();

            bool catched = false;

            // Act

            ldr.Take(crg);
            try
            {
                ldr.TakeFromStock(stck);
            }
            catch (InvalidOperationException e)
            {
                if (e is not null) catched = true;
            }

            // Assert

            Assert.True(catched);
        }

        [Fact]
        public void TakeFromStockStockIsEmptyInvalidOperationExceptionTest()
        {
            // Arrange
            Loader ldr = new Loader();
            Stock stck = new Stock();

            bool catched = false;

            // Act

            try
            {
                ldr.TakeFromStock(stck);
            }
            catch (InvalidOperationException e)
            {
                if (e is not null) catched = true;
            }

            // Assert

            Assert.True(catched);
        }
    }
}
