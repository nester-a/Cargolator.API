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
        public void AddRangeArrayParamTest()
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
        public void AddRangeCollectionParamTest()
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
            ldr.Take(stck.RemoveCargo());

            bool result = stck.GetCount() == 0 && ldr.TakedCargo.Equals(crg) && crg.Status == CargoStatus.OnHands;

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void TryRemoveCargoTrueTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 1, 1);
            Loader ldr = new Loader();
            Cargo crg2;

            // Act
            stck.AddCargo(crg);
            bool action = stck.TryRemoveCargo(out crg2);
            ldr.Take(crg2);

            bool result = action && ldr.TakedCargo.Equals(crg) && crg.Status == CargoStatus.OnHands && stck.GetCount() == 0;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryRemoveCargoStockIsEmptyFalseTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg;
            Loader ldr = new Loader();

            // Act
            bool action1 = stck.TryRemoveCargo(out crg);
            bool action2 = ldr.TryTake(crg);

            bool result = !action1 && !action2 && crg is null;

            // Assert
            Assert.True(result);
        }
    }
}
