using Cargolator.API.Base;
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
            stck.AddOnStock(crg);

            bool result = stck.CargosStock.Count == 1 && stck.CargosStock.Contains(crg);

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
            stck.AddRangeOnStock(crg1, crg2);

            bool result = stck.CargosStock.Count == 2 && stck.CargosStock.Contains(crg1) && stck.CargosStock.Contains(crg2);

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
            stck.AddRangeOnStock(crgs);

            bool result = stck.CargosStock.Count == 2 && stck.CargosStock.Contains(new Cargo(0, 1, 1)) && stck.CargosStock.Contains(new Cargo(1, 2, 2));

            // Assert
            Assert.True(result);
        }
    }
}
