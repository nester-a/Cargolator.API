using Cargolator.API.Base;
using Cargolator.API.Base.AbstractClasses;
using Cargolator.API.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests.EntitysTests
{
    public class WorkerTests
    {
        [Fact]
        public void TakeTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 2, 2);

            // Act
            wrk.Take(crg);

            bool result = wrk.TakedCargo is not null && ReferenceEquals(wrk.TakedCargo, crg) && crg.Status == CargoStatus.OnHands;

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void TryTakeTakedCargoInNotNullFalseTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 2, 2);
            Cargo crg2 = new Cargo(1, 2, 2);

            // Act
            wrk.Take(crg);

            bool result = wrk.TryTake(crg2);

            // Assert
            Assert.True(!result);
        }
        [Fact]
        public void TryTakeCargoIsNullFalseTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = null;

            // Act

            bool result = wrk.TryTake(crg);

            // Assert
            Assert.True(!result);
        }
        [Fact]
        public void TryTakeCargoStatusOnHandsFalseTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 2, 2);

            // Act
            crg.ChangeStatus(CargoStatus.OnHands);

            bool result = wrk.TryTake(crg);

            // Assert
            Assert.True(!result);
        }
        [Fact]
        public void TryTakeTrueTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 2, 2);

            // Act
            bool result = wrk.TryTake(crg);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void DropCargoTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 2, 2);

            // Act
            wrk.Take(crg);
            wrk.DropCargo();

            bool result = wrk.TakedCargo is null && crg.Status == CargoStatus.Wait;

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void DropCargoWithInConatinerStatusParamTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 2, 2);

            // Act
            wrk.Take(crg);
            wrk.DropCargo(CargoStatus.InContainer);

            bool result = wrk.TakedCargo is null && crg.Status == CargoStatus.InContainer;

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void DropCargoWithOnStockStatusParamTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 2, 2);

            // Act
            wrk.Take(crg);
            wrk.DropCargo(CargoStatus.OnStock);

            bool result = wrk.TakedCargo is null && crg.Status == CargoStatus.OnStock;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryDropCargoTakedCargoIsNullFalseTest()
        {
            // Arrange
            Worker wrk = new Loader();

            // Act
            bool result = wrk.TryDropCargo();

            // Assert
            Assert.True(!result);
        }
        [Fact]
        public void TryDropCargoWithInHandsStatusParamFalseTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 1, 1);

            // Act
            wrk.Take(crg);
            bool result = wrk.TryDropCargo(CargoStatus.OnHands);

            // Assert
            Assert.True(!result);
        }
        [Fact]
        public void TryDropCargoWithInConatinerStatusParamTrueTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 2, 2);

            // Act
            wrk.Take(crg);

            bool result = wrk.TryDropCargo(CargoStatus.InContainer) && wrk.TakedCargo is null && crg.Status == CargoStatus.InContainer;

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void TryDropCargoWithOnStockStatusParamTrueTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 2, 2);

            // Act
            wrk.Take(crg);

            bool result = wrk.TryDropCargo(CargoStatus.OnStock) && wrk.TakedCargo is null && crg.Status == CargoStatus.OnStock;

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void TryDropCargoTrueTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 2, 2);

            // Act
            wrk.Take(crg);

            bool result = wrk.TryDropCargo() && wrk.TakedCargo is null && crg.Status == CargoStatus.Wait;

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void TakeFromWorkerTest()
        {
            // Arrange
            Worker wrk1 = new Loader();
            Worker wrk2 = new Loader();
            Cargo crg = new Cargo(0, 2, 2);

            // Act
            wrk1.Take(crg);
            wrk2.TakeFromWorker(wrk1);

            bool result = wrk2.TakedCargo.Equals(crg) && wrk1.TakedCargo is null && crg.Status == CargoStatus.OnHands;

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void TryTakeFromWorkerThisWorkerTakedCargoIsNotNullFalseTest()
        {
            // Arrange
            Worker wrk1 = new Loader();
            Worker wrk2 = new Loader();
            Cargo crg = new Cargo(0, 2, 2);
            Cargo crg2 = new Cargo(1, 3, 3);

            // Act
            wrk1.Take(crg);
            wrk2.Take(crg2);

            bool result = wrk2.TryTakeFromWorker(wrk1);

            // Assert
            Assert.True(!result);
        }
        [Fact]
        public void TryTakeFromWorkerWorkerTakedCargoIsNullFalseTest()
        {
            // Arrange
            Worker wrk1 = new Loader();
            Worker wrk2 = new Loader();

            // Act

            bool result = wrk1.TryTakeFromWorker(wrk2);

            // Assert
            Assert.True(!result);
        }
        [Fact]
        public void TryTakeFromWorkerWorkerIsNullFalseTest()
        {
            // Arrange
            Worker wrk1 = new Loader();
            Worker wrk2 = null;

            // Act

            bool result = wrk1.TryTakeFromWorker(wrk2);

            // Assert
            Assert.True(!result);
        }
        [Fact]
        public void TakeFromWorkerTrueTest()
        {
            // Arrange
            Worker wrk1 = new Loader();
            Worker wrk2 = new Loader();
            Cargo crg = new Cargo(0, 2, 2);

            // Act
            wrk1.Take(crg);

            bool result = wrk2.TryTakeFromWorker(wrk1) && wrk2.TakedCargo.Equals(crg) && wrk1.TakedCargo is null;

            // Assert
            Assert.True(result);
        }
    }
}
