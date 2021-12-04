using Cargolator.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests.EventsTests
{
    public class ContainerEventsTests
    {
        EventTestHelper helper = new EventTestHelper();

        [Fact]
        public void AddCargoEventTest()
        {
            Container cnt = new Container(5, 5);
            Cargo crg = new Cargo(0, 1, 1);
            cnt.ContainerEvent += Container_ContainerEvent;

            cnt.AddCargo(crg);

            bool expected = helper.CheckTrue();

            Assert.True(expected);
        }

        [Fact]
        public void AddRangeArrayParamEventTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo crg1 = new Cargo(0, 1, 1);
            Cargo crg2 = new Cargo(1, 2, 2);

            cnt.ContainerEvent += Container_ContainerEvent;

            // Act
            cnt.AddRangeCargo(crg1, crg2);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void AddRangeCollectionParamEventTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            List<Cargo> crgs = new List<Cargo>()
            {
                new Cargo(0, 1, 1),
                new Cargo(1, 2, 2),
            };

            cnt.ContainerEvent += Container_ContainerEvent;

            // Act
            helper.ClearMessages();
            cnt.AddRangeCargo(crgs);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void RemoveCargoEventTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo crg = new Cargo(0, 1, 1);
            Unloader unldr = new Unloader();

            cnt.ContainerEvent += Container_ContainerEvent;

            // Act
            helper.ClearMessages();

            cnt.AddCargo(crg);
            unldr.Take(cnt.RemoveCargo());

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryRemoveCargoEventPositiveResultTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo crg = new Cargo(0, 1, 1);
            Unloader unldr = new Unloader();
            Cargo crg2;

            cnt.ContainerEvent += Container_ContainerEvent;

            // Act
            helper.ClearMessages();
            cnt.AddCargo(crg);
            bool action = cnt.TryRemoveCargo(out crg2);
            unldr.Take(crg2);

            bool expected = helper.CheckTrue() && action;

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void TryRemoveCargoEventNegativeResultTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Cargo crg = new Cargo(0, 1, 1);
            Cargo crg2;

            cnt.ContainerEvent += Container_ContainerEvent;

            // Act
            helper.ClearMessages();
            bool action = cnt.TryRemoveCargo(out crg2);

            bool expected = helper.CheckFalse();

            // Assert
            Assert.True(expected);
        }

        private void Container_ContainerEvent(object sender, API.Base.EventArgs.ContainerEventArgs e)
        {
            helper.EventRouting(e);
        }
    }
}
