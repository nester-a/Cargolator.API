using Cargolator.API.Base.AbstractClasses;
using Cargolator.API.Base;
using Xunit;
using Cargolator.API.Base.Enums;
using Cargolator.API.Base.EventArgs;

namespace Cargolator.Tests.EventsTests
{
    public class WorkerEventsTests
    {
        EventTestHelper helper = new EventTestHelper();

        [Fact]
        public void TakeMethodTakeCargoEventTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            wrk.TakeCargoEvent += Worker_TakeCargoEvent;

            // Act
            wrk.Take(crg);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryTakeMethodTakeCargoEventPositiveResultTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            wrk.TakeCargoEvent += Worker_TakeCargoEvent;

            // Act
            bool result = wrk.TryTake(crg);

            bool expected = helper.CheckTrue() && result;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryTakeMethodTakedCargoIsNotNullTakeCargoEventNegativeResultTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg1 = new Cargo(0, 1, 1);
            Cargo crg2 = new Cargo(1, 1, 1);
            wrk.TakeCargoEvent += Worker_TakeCargoEvent;

            // Act

            wrk.Take(crg1);
            bool result = wrk.TryTake(crg2);

            bool expected = helper.CheckFalse() && !result;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryTakeMethodCargoIsNullTakeCargoEventNegativeResultTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = null;
            wrk.TakeCargoEvent += Worker_TakeCargoEvent;

            // Act
            bool result = wrk.TryTake(crg);

            bool expected = helper.CheckFalse() && !result;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryTakeMethodCargoStatusIsOnHandsTakeCargoEventNegativeResultTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            wrk.TakeCargoEvent += Worker_TakeCargoEvent;

            // Act

            crg.ChangeStatus(CargoStatus.OnHands);
            bool result = wrk.TryTake(crg);

            bool expected = helper.CheckFalse() && !result;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void DropCargoMethodDropCargoEventTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            wrk.DropCargoEvent += Worker_DropCargoEvent;

            // Act
            
            wrk.Take(crg);
            wrk.DropCargo();

            bool expected = helper.CheckTrue() && crg is not null && crg.Status == CargoStatus.Wait && wrk.TakedCargo is null;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void DropCargoMethodWithDropCargoStatusArgumentDropCargoEventTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            wrk.DropCargoEvent += Worker_DropCargoEvent;

            // Act

            wrk.Take(crg);
            wrk.DropCargo(CargoStatus.InContainer);

            bool expected = helper.CheckTrue() && crg is not null && crg.Status == CargoStatus.InContainer && wrk.TakedCargo is null;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryDropCargoMethodDropCargoEventPositiveResultTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            wrk.DropCargoEvent += Worker_DropCargoEvent;

            // Act

            wrk.Take(crg);
            bool result = wrk.TryDropCargo();

            bool expected = helper.CheckTrue() && result;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryDropCargoMethodTakedCargoIsNullDropCargoEventNegativeResultTest()
        {
            // Arrange
            Worker wrk = new Loader();
            wrk.DropCargoEvent += Worker_DropCargoEvent;

            // Act

            bool result = wrk.TryDropCargo();

            bool expected = helper.CheckFalse() && !result;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryDropCargoMethodWithDropCargoStatusArgumentDropCargoEventPositiveResultTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            wrk.DropCargoEvent += Worker_DropCargoEvent;

            // Act

            wrk.Take(crg);
            bool result = wrk.TryDropCargo(CargoStatus.InContainer);

            bool expected = helper.CheckTrue() && result && crg.Status == CargoStatus.InContainer;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryDropCargoMethodWithDropCargoStatusArgumentTakedCargoIsNullDropCargoEventNegativeResultTest()
        {
            // Arrange
            Worker wrk = new Loader();
            wrk.DropCargoEvent += Worker_DropCargoEvent;

            // Act

            bool result = wrk.TryDropCargo(CargoStatus.InContainer);

            bool expected = helper.CheckFalse() && !result;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryDropCargoMethodWithDropCargoStatusArgumentDropCargoStatusIsOnHandsDropCargoEventNegativeResultTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            wrk.DropCargoEvent += Worker_DropCargoEvent;

            // Act
            wrk.Take(crg);
            bool result = wrk.TryDropCargo(CargoStatus.OnHands);

            bool expected = helper.CheckFalse() && !result;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TakeFromWorkerMethodTakeCargoFromWorkerEventTest()
        {
            // Arrange
            Worker wrk1 = new Loader();
            Worker wrk2 = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            wrk1.TakeCargoFromWorkerEvent += Worker_TakeCargoFromWorkerEvent;

            // Act
            wrk2.Take(crg);
            wrk1.TakeFromWorker(wrk2);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TakeFromWorkerMethodTakeCargoEventDropCargoEventTakeCargoFromWorkerEventTest()
        {
            // Arrange
            Worker wrk1 = new Loader();
            Worker wrk2 = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            wrk1.TakeCargoEvent += Worker_TakeCargoEvent;
            wrk1.TakeCargoFromWorkerEvent += Worker_TakeCargoFromWorkerEvent;
            wrk2.DropCargoEvent += Worker_DropCargoEvent;

            // Act
            wrk2.Take(crg);
            wrk1.TakeFromWorker(wrk2);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryTakeFromWorkerMethodTakeCargoFromWorkerEventPositiveResultTest()
        {
            // Arrange
            Worker wrk1 = new Loader();
            Worker wrk2 = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            wrk1.TakeCargoFromWorkerEvent += Worker_TakeCargoFromWorkerEvent;

            // Act
            wrk2.Take(crg);
            bool result = wrk1.TryTakeFromWorker(wrk2);

            bool expected = helper.CheckTrue() && result;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryTakeFromWorkerMethodWorkerIsNullTakeCargoFromWorkerEventNegativeResultTest()
        {
            // Arrange
            Worker wrk1 = new Loader();
            Worker wrk2 = null;
            Cargo crg = new Cargo(0, 1, 1);
            wrk1.TakeCargoFromWorkerEvent += Worker_TakeCargoFromWorkerEvent;

            // Act
            bool result = wrk1.TryTakeFromWorker(wrk2);

            bool expected = helper.CheckFalse() && !result;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryTakeFromWorkerMethodWorkerTakedCargoIsNullTakeCargoFromWorkerEventNegativeResultTest()
        {
            // Arrange
            Worker wrk1 = new Loader();
            Worker wrk2 = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            wrk1.TakeCargoFromWorkerEvent += Worker_TakeCargoFromWorkerEvent;

            // Act
            bool result = wrk1.TryTakeFromWorker(wrk2);

            bool expected = helper.CheckFalse() && !result;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryTakeFromWorkerMethodTakedCargoIsNotNullTakeCargoFromWorkerEventNegativeResultTest()
        {
            // Arrange
            Worker wrk1 = new Loader();
            Worker wrk2 = new Loader();
            Cargo crg1 = new Cargo(0, 1, 1);
            Cargo crg2 = new Cargo(1, 2, 2);
            wrk1.TakeCargoFromWorkerEvent += Worker_TakeCargoFromWorkerEvent;

            // Act
            wrk1.Take(crg1);
            wrk2.Take(crg2);

            bool result = wrk1.TryTakeFromWorker(wrk2);

            bool expected = helper.CheckFalse() && !result;

            // Assert
            Assert.True(expected);
        }

        private void Worker_TakeCargoFromWorkerEvent(object sender, WorkerEventArgs e)
        {
            helper.EventRouting(e);
        }
        private void Worker_DropCargoEvent(object sender, WorkerEventArgs e)
        {
            helper.EventRouting(e);
        }
        private void Worker_TakeCargoEvent(object sender, WorkerEventArgs e)
        {
            helper.EventRouting(e);
        }
    }
}
