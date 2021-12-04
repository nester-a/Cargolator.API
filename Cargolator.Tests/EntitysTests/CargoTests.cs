using Cargolator.API.Base;
using Cargolator.API.Base.AbstractClasses;
using Cargolator.API.Base.Enums;
using Xunit;

namespace Cargolator.Tests.EntitysTests
{
    public class CargoTests
    {
        [Fact]
        public void EqualsTrueTest()
        {
            // Arrange
            Cargo crg1 = new Cargo(0, 2, 2);
            Cargo crg2 = new Cargo(0, 2, 2);

            // Act
            // Assert
            Assert.Equal<Cargo>(crg1, crg2);
        }
        [Fact]
        public void EqualsFalseTest()
        {
            // Arrange
            Cargo crg1 = new Cargo(0, 2, 2);
            Cargo crg2 = new Cargo(1, 3, 3);

            // Act
            bool result = crg1.Equals(crg2);

            // Assert
            Assert.True(!result);
        }
        [Fact]
        public void CargoEqualsWorkerFalseTest()
        {
            // Arrange
            Cargo crg1 = new Cargo(0, 2, 2);
            Worker wrk = new Loader();

            // Act
            bool result = crg1.Equals(wrk);

            // Assert
            Assert.True(!result);
        }
        [Fact]
        public void ChangeStatusOnStockTest()
        {
            // Arrange
            Cargo crg1 = new Cargo(0, 2, 2);

            // Act
            crg1.ChangeStatus(CargoStatus.OnStock);

            bool result = crg1.Status == CargoStatus.OnStock;

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void ChangeStatusInContainerTest()
        {
            // Arrange
            Cargo crg1 = new Cargo(0, 2, 2);

            // Act
            crg1.ChangeStatus(CargoStatus.InContainer);

            bool result = crg1.Status == CargoStatus.InContainer;

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void ChangeStatusOnHandsTest()
        {
            // Arrange
            Cargo crg1 = new Cargo(0, 2, 2);

            // Act
            crg1.ChangeStatus(CargoStatus.OnHands);

            bool result = crg1.Status == CargoStatus.OnHands;

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void ChangeStatusWaitTest()
        {
            // Arrange
            Cargo crg1 = new Cargo(0, 2, 2);

            // Act
            crg1.ChangeStatus(CargoStatus.OnHands);
            crg1.ChangeStatus(CargoStatus.Wait);

            bool result = crg1.Status == CargoStatus.Wait;

            // Assert
            Assert.True(result);
        }
    }
}
