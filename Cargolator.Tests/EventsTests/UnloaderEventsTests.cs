using Cargolator.API.Base;
using Cargolator.API.Base.EventArgs;
using Xunit;

namespace Cargolator.Tests.EventsTests
{
    public class UnloaderEventsTests
    {
        EventTestHelper helper = new EventTestHelper();

        [Fact]
        public void UnloadEventTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Container cnt = new Container(10, 10);
            Cargo crg = new Cargo(0, 5, 5);
            unldr.UnloadCargoEvent += Unloader_UnloadCargoEvent;

            // Act
            cnt.AddCargo(crg);
            unldr.Unload(cnt);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryUnloadEventPositiveResultTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Container cnt = new Container(10, 10);
            Cargo crg = new Cargo(0, 5, 5);
            unldr.UnloadCargoEvent += Unloader_UnloadCargoEvent;

            // Act
            cnt.AddCargo(crg);

            unldr.TryUnload(cnt);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryUnloadContainerLoadedCargoEqualsZeroEventNegativeResultTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Container cnt = new Container(10, 10);
            unldr.UnloadCargoEvent += Unloader_UnloadCargoEvent;

            // Act
            unldr.TryUnload(cnt);

            bool expected = helper.CheckFalse();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryUnloadTakedCargoIsNullEventNegativeResultTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Container cnt = new Container(10, 10);
            Cargo crg = new Cargo(0, 5, 5);
            Cargo crg2 = new Cargo(1, 2, 2);
            unldr.UnloadCargoEvent += Unloader_UnloadCargoEvent;

            // Act
            unldr.Take(crg2);
            cnt.AddCargo(crg);

            unldr.TryUnload(cnt);

            bool expected = helper.CheckFalse();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void PlaceToStockEventTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Cargo crg = new Cargo(0, 5, 5);
            Stock stck = new Stock();
            unldr.PlaceToStockCargoEvent += Unloader_PlaceToStockCargoEvent;

            // Act
            unldr.Take(crg);
            unldr.PlaceToStock(stck);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryPlaceToStockEventPositiveResultTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Cargo crg = new Cargo(0, 5, 5);
            Stock stck = new Stock();
            unldr.PlaceToStockCargoEvent += Unloader_PlaceToStockCargoEvent;

            // Act
            unldr.Take(crg);

            unldr.TryPlaceToStock(stck);
            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryPlaceToStockEventNegativeResultTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Cargo crg = new Cargo(0, 5, 5);
            Stock stck = null;
            unldr.PlaceToStockCargoEvent += Unloader_PlaceToStockCargoEvent;

            // Act
            unldr.Take(crg);

            unldr.TryPlaceToStock(stck);
            bool expected = helper.CheckFalse();

            // Assert
            Assert.True(expected);
        }

        private void Unloader_UnloadCargoEvent(object sender, WorkerEventArgs e)
        {
            helper.EventRouting(e);
        }
        private void Unloader_PlaceToStockCargoEvent(object sender, WorkerEventArgs e)
        {
            helper.EventRouting(e);
        }
    }
}
