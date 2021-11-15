using Cargolator.API.Base;
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

            bool result = ldr.TakedCargo is null && cnt.LoadedCargo.Contains(crg);

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
        public void TryLoadFalseTest()
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
        public void TryRotateFalseTest()
        {
            // Arrange
            Loader ldr = new Loader();

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
            stck.CargosStock.Enqueue(crg);
            ldr.TakeFromStock(stck);

            bool result = stck.CargosStock.Count == 0 && ldr.TakedCargo.Equals(crg);

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
            stck.CargosStock.Enqueue(crg);

            bool result = ldr.TryTakeFromStock(stck);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void TryTakeFromStockFalseTest()
        {
            // Arrange
            Stock stck = new Stock();
            Loader ldr = new Loader();

            // Act
            bool result = ldr.TryTakeFromStock(stck);

            // Assert
            Assert.True(!result);
        }
    }
}
