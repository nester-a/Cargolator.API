using Cargolator.API.Base;
using Cargolator.API.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests
{
    public class LoaderTests
    {
        [Fact]
        public void LoadTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 1, 1);

            // Act
            ldr.Take(crg);
            ldr.Load(cnt);

            bool result = ldr.TakedCargo is null && cnt.LoadedCargo.Contains(crg) && crg.Status == CargoStatus.InContainer;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryLoadTrueTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 1, 1);

            // Act
            ldr.Take(crg);

            bool result = ldr.TryLoad(cnt);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryLoadContainerIsNullFalseTest()
        {
            // Arrange
            Container cnt = null;
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 1, 1);

            // Act
            ldr.Take(crg);

            bool result = ldr.TryLoad(cnt);

            // Assert
            Assert.True(!result);
        }

        [Fact]
        public void TryLoadTakedCargoIsNullFalseTest()
        {
            // Arrange
            Container cnt = null;
            Loader ldr = new Loader();

            // Act
            bool result = ldr.TryLoad(cnt);

            // Assert
            Assert.True(!result);
        }

        [Fact]
        public void RotateTest()
        {
            // Arrange
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 2, 1);

            // Act
            ldr.Take(crg);
            ldr.Rotate();

            bool result = ldr.TakedCargo.Id.Equals(0) && ldr.TakedCargo.Length.Equals(1) && ldr.TakedCargo.Width.Equals(2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryRotateTrueTest()
        {
            // Arrange
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 2, 1);

            // Act
            ldr.Take(crg);

            bool result = ldr.TryRotate();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryRotateTakedCargoIsNullFalseTest()
        {
            // Arrange
            Loader ldr = new Loader();

            // Act
            bool result = ldr.TryRotate();

            // Assert
            Assert.True(!result);
        }

        [Fact]
        public void TryRotateTakedCargoIsSquareFalseTest()
        {
            // Arrange
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 2, 2);

            // Act
            bool result = ldr.TryRotate();

            // Assert
            Assert.True(!result);
        }

        [Fact]
        public void TakeFromStockTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 2, 2);
            Loader ldr = new Loader();

            // Act
            stck.AddCargo(crg);
            ldr.TakeFromStock(stck);

            bool result = stck.GetCount() == 0 && ldr.TakedCargo.Equals(crg) && crg.Status == CargoStatus.OnHands;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryTakeFromStockTrueTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 2, 2);
            Loader ldr = new Loader();

            // Act
            stck.AddCargo(crg);

            bool result = ldr.TryTakeFromStock(stck);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryTakeFromStockStockIsEmptyFalseTest()
        {
            // Arrange
            Stock stck = new Stock();
            Loader ldr = new Loader();

            // Act
            bool result = ldr.TryTakeFromStock(stck);

            // Assert
            Assert.True(!result);
        }

        [Fact]
        public void TryTakeFromStockTakedCargoIsNotNullFalseTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 2, 2);
            Cargo crg2 = new Cargo(1, 2, 2);
            Loader ldr = new Loader();

            // Act
            stck.AddCargo(crg);
            ldr.Take(crg2);

            bool result = ldr.TryTakeFromStock(stck);

            // Assert
            Assert.True(!result);
        }
    }
}
