using Cargolator.API.Base;
using Cargolator.API.Base.Enums;
using Xunit;

namespace Cargolator.Tests.EntitysTests
{
    public class UnloaderTests
    {
        [Fact]
        public void UnloadTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Container cnt = new Container(10, 10);
            Cargo crg = new Cargo(0, 5, 5);

            // Act
            cnt.AddCargo(crg);
            unldr.Unload(cnt);

            bool result = cnt.GetCount() == 0 && unldr.TakedCargo.Equals(crg) && unldr.TakedCargo.Status == CargoStatus.OnHands;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryUnloadTrueTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Container cnt = new Container(10, 10);
            Cargo crg = new Cargo(0, 5, 5);

            // Act
            cnt.AddCargo(crg);
            
            bool result = unldr.TryUnload(cnt);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryUnloadContainerLoadedCargoEqualsZeroFalseTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Container cnt = new Container(10, 10);
            
            // Act
            bool result = unldr.TryUnload(cnt);

            // Assert
            Assert.True(!result);
        }

        [Fact]
        public void TryUnloadTakedCargoIsNullFalseTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Container cnt = new Container(10, 10);
            Cargo crg = new Cargo(0, 5, 5);
            Cargo crg2 = new Cargo(1, 2, 2);

            // Act
            unldr.Take(crg2);
            cnt.AddCargo(crg);

            bool result = unldr.TryUnload(cnt);

            // Assert
            Assert.True(!result);
        }

        [Fact]
        public void PlaceToStockTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Cargo crg = new Cargo(0, 5, 5);
            Stock stck = new Stock();

            // Act
            unldr.Take(crg);
            unldr.PlaceToStock(stck);

            bool result = unldr.TakedCargo is null && stck.GetCount() == 1 && stck.Contains(crg) && crg.Status == CargoStatus.OnStock;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryPlaceToStockTrueTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Cargo crg = new Cargo(0, 5, 5);
            Stock stck = new Stock();

            // Act
            unldr.Take(crg);

            bool result = unldr.TryPlaceToStock(stck);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryPlaceToStockStockIsNullFalseTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Cargo crg = new Cargo(0, 5, 5);
            Stock stck = null;

            // Act
            unldr.Take(crg);

            bool result = unldr.TryPlaceToStock(stck);

            // Assert
            Assert.True(!result);
        }

        [Fact]
        public void TryPlaceToStockTakedCargoIsNullFalseTest()
        {
            // Arrange
            Unloader unldr = new Unloader();
            Stock stck = new Stock();

            // Act
            bool result = unldr.TryPlaceToStock(stck);

            // Assert
            Assert.True(!result);
        }
    }
}
