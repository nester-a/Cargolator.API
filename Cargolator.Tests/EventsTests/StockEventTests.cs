using Cargolator.API.Base;
using Cargolator.API.Base.EventArgs;
using System.Collections.Generic;
using Xunit;

namespace Cargolator.Tests.EventsTests
{
    public class StockEventTests
    {
        EventTestHelper helper = new EventTestHelper();

        [Fact]
        public void AddOnStockEventTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 1, 1);
            stck.StockEvent += Stock_StockEvent;

            // Act
            stck.AddCargo(crg);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void AddRangeArrayParamEventTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg1 = new Cargo(0, 1, 1);
            Cargo crg2 = new Cargo(1, 2, 2);
            stck.StockEvent += Stock_StockEvent;

            // Act
            stck.AddRangeCargo(crg1, crg2);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void AddRangeCollectionParamEventTest()
        {
            // Arrange
            Stock stck = new Stock();
            List<Cargo> crgs = new List<Cargo>()
            {
                new Cargo(0, 1, 1),
                new Cargo(1, 2, 2),
            };
            stck.StockEvent += Stock_StockEvent;

            // Act
            stck.AddRangeCargo(crgs);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void RemoveCargoEventTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 1, 1);
            Loader ldr = new Loader();
            stck.StockEvent += Stock_StockEvent;

            // Act
            stck.AddCargo(crg);
            ldr.Take(stck.RemoveCargo());

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryRemoveCargoEventPositiveTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 1, 1);
            Loader ldr = new Loader();
            Cargo crg2;
            stck.StockEvent += Stock_StockEvent;

            // Act
            stck.AddCargo(crg);
            stck.TryRemoveCargo(out crg2);
            ldr.Take(crg2);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryRemoveCargoEventNegativeTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg;
            Loader ldr = new Loader();
            stck.StockEvent += Stock_StockEvent;

            // Act
            stck.TryRemoveCargo(out crg);
            ldr.TryTake(crg);

            bool expected = helper.CheckFalse();

            // Assert
            Assert.True(expected);
        }


        private void Stock_StockEvent(object sender, StockEventArgs e)
        {
            helper.EventRouting(e);
        }
    }
}
