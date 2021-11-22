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
    public class StockTests
    {
        [Fact]
        public void AddOnStockTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 1, 1);

            // Act
            stck.AddCargo(crg);

            bool result = stck.GetCount() == 1 && stck.CargosStock.Contains(crg) && crg.Status == CargoStatus.OnStock;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddRangeOnStockArrayTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg1 = new Cargo(0, 1, 1);
            Cargo crg2 = new Cargo(1, 2, 2);

            // Act
            stck.AddRangeCargo(crg1, crg2);

            bool result = stck.GetCount() == 2 && stck.CargosStock.Contains(crg1) && stck.CargosStock.Contains(crg2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddRangeOnStockCollectionTest()
        {
            // Arrange
            Stock stck = new Stock();
            List<Cargo> crgs = new List<Cargo>()
            {
                new Cargo(0, 1, 1),
                new Cargo(1, 2, 2),
            };

            // Act
            stck.AddRangeCargo(crgs);

            bool result = stck.GetCount() == 2 && stck.CargosStock.Contains(new Cargo(0, 1, 1)) && stck.CargosStock.Contains(new Cargo(1, 2, 2));

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetCountTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 1, 1);

            // Act
            stck.AddCargo(crg);

            // Assert
            Assert.Equal(1, stck.GetCount());
        }
        [Fact]
        public void RemoveCargoTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 1, 1);
            Loader ldr = new Loader();

            // Act
            stck.AddCargo(crg);
            ldr.TakeFromStock(stck);

            bool result = stck.GetCount() == 0 && ldr.TakedCargo.Equals(crg) && crg.Status == CargoStatus.OnHands;

            // Assert
            Assert.True(result);
        }

    }
}
