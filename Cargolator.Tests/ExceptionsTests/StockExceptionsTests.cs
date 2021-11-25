using Cargolator.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests.ExceptionsTests
{
    public class StockExceptionsTests
    {
        [Fact]
        public void AddCargoCargoArgumentNullExceptionTest()
        {
            // Arrange
            Stock stck = new Stock();

            bool catched = false;

            // Act
            try
            {
                stck.AddCargo(null);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert

            Assert.True(catched);
        }

        [Fact]
        public void AddRangeCargoArrayArgumentNullExceptionTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo[] crgs = null;

            bool catched = false;

            // Act
            try
            {
                stck.AddRangeCargo(crgs);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert

            Assert.True(catched);
        }

        [Fact]
        public void AddRangeCargoCollectionArgumentNullExceptionTest()
        {
            // Arrange
            Stock stck = new Stock();
            List<Cargo> crgs = null;

            bool catched = false;

            // Act
            try
            {
                stck.AddRangeCargo(crgs);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert

            Assert.True(catched);
        }

        [Fact]
        public void ContainsCargoArgumentNullExceptionTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 1, 1);
            Cargo crg2 = null;
            

            bool catched = false;

            // Act

            stck.AddCargo(crg);

            try
            {
                stck.Contains(crg2);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert

            Assert.True(catched);
        }

        [Fact]
        public void ContainsStockIsEmptyInvalidOperationExceptionTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 1, 1);

            bool catched = false;

            // Act


            try
            {
                stck.Contains(crg);
            }
            catch (InvalidOperationException e)
            {
                if (e is not null) catched = true;
            }

            // Assert

            Assert.True(catched);
        }

        [Fact]
        public void RemoveCargoStockIsEmptyInvalidOperationExceptionTest()
        {
            // Arrange
            Stock stck = new Stock();

            bool catched = false;

            // Act
            try
            {
                stck.RemoveCargo();
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
