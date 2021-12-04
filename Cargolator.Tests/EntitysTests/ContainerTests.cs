using Cargolator.API.Base;
using Cargolator.API.Base.Enums;
using System.Collections.Generic;
using Xunit;

namespace Cargolator.Tests.EntitysTests
{
    public class ContainerTests
    {
        [Fact]
        public void AddCargoTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo crg = new Cargo(0, 1, 1);

            // Act
            cnt.AddCargo(crg);
            bool result = cnt.Contains(crg) && cnt.GetCount() == 1 && crg.Status == CargoStatus.InContainer;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetCountTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo crg = new Cargo(0, 1, 1);
            int exp = 1;

            // Act
            cnt.AddCargo(crg);
            int result = cnt.GetCount();

            // Assert
            Assert.Equal(exp, result);
        }

        [Fact]
        public void AddRangeArrayParamTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo crg1 = new Cargo(0, 1, 1);
            Cargo crg2 = new Cargo(1, 2, 2);

            // Act
            cnt.AddRangeCargo(crg1, crg2);

            bool result = cnt.GetCount() == 2 && cnt.Contains(crg1) && cnt.Contains(crg2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddRangeCollectionParamTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            List<Cargo> crgs = new List<Cargo>()
            {
                new Cargo(0, 1, 1),
                new Cargo(1, 2, 2),
            };

            // Act
            cnt.AddRangeCargo(crgs);

            bool result = cnt.GetCount() == 2 && cnt.Contains(new Cargo(0, 1, 1)) && cnt.Contains(new Cargo(1, 2, 2));

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveCargoTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo crg = new Cargo(0, 1, 1);
            Unloader unldr = new Unloader();

            // Act
            cnt.AddCargo(crg);
            unldr.Take(cnt.RemoveCargo());

            bool result = cnt.GetCount() == 0 && unldr.TakedCargo.Equals(crg) && crg.Status == CargoStatus.OnHands;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryRemoveCargoTrueTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo crg = new Cargo(0, 1, 1);
            Unloader unldr = new Unloader();
            Cargo crg2;

            // Act
            cnt.AddCargo(crg);
            bool action = cnt.TryRemoveCargo(out crg2);
            unldr.Take(crg2);

            bool result = action && unldr.TakedCargo.Equals(crg) && crg.Status == CargoStatus.OnHands && cnt.GetCount() == 0;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryRemoveCargoStockIsEmptyFalseTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo crg;
            Unloader unldr = new Unloader();

            // Act
            bool action1 = cnt.TryRemoveCargo(out crg);
            bool action2 = unldr.TryTake(crg);

            bool result = !action1 && !action2 && crg is null;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ContainsTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo crg = new Cargo(0, 1, 1);

            // Act
            cnt.AddCargo(crg);

            bool result = cnt.Contains(crg);

            // Assert
            Assert.True(result);
        }
    }
}
