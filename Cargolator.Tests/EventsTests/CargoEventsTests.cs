using Cargolator.API.Base;
using Cargolator.API.Base.Enums;
using Xunit;

namespace Cargolator.Tests.EventsTests
{
    public class CargoEventsTests
    {
        EventTestHelper helper = new EventTestHelper();

        [Fact]
        public void CangeStatusEventPositiveResultTest()
        {
            Cargo crg = new Cargo(0, 1, 1);
            crg.CargoEvent += Cargo_CargoEvent;

            // Act
            crg.ChangeStatus(CargoStatus.InContainer);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void CangeStatusEventNegativeResultTest()
        {
            Cargo crg = new Cargo(0, 1, 1);
            crg.CargoEvent += Cargo_CargoEvent;

            // Act
            crg.ChangeStatus(CargoStatus.Wait);

            bool expected = helper.CheckFalse();

            // Assert
            Assert.True(expected);
        }

        private void Cargo_CargoEvent(object sender, API.Base.EventArgs.CargoEventArgs e)
        {
            helper.EventRouting(e);
        }
    }
}
