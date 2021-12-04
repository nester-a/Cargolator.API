using Cargolator.API.Base;
using Cargolator.API.Base.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests.EventsTests
{
    public class SupervisorEventsTests
    {
        EventTestHelper helper = new EventTestHelper();

        [Fact]
        public void FindLoadPlaceEventPositiveResultTest()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo(0, 5, 5);
            sv.SupervisorEvent += Supervisor_SupervisorEvent;

            // Act
            sv.FindPlaceAndLoadOnIt(crg);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void FindLoadPlaceEventNegativeResultTest()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg1 = new Cargo(0, 10, 10);
            Cargo crg2 = new Cargo(0, 10, 10);
            sv.SupervisorEvent += Supervisor_SupervisorEvent;

            // Act
            sv.FindPlaceAndLoadOnIt(crg1);
            sv.FindPlaceAndLoadOnIt(crg2);

            bool expected = helper.CheckFalse();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void CheckSquareEventPositiveResultTest()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo(0, 5, 5);
            Point p = new Point(0, 0);
            sv.SupervisorEvent += Supervisor_SupervisorEvent;

            // Act
            sv.CheckSquare(p, crg);
            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void CheckSquareEventNegativeResultTest()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg1 = new Cargo(0, 5, 5);
            Cargo crg2 = new Cargo(1, 3, 5);
            Point p = new Point(0, 0);
            sv.SupervisorEvent += Supervisor_SupervisorEvent;

            // Act
            sv.FindPlaceAndLoadOnIt(crg1);
            sv.CheckSquare(p, crg2);

            bool expected = helper.CheckFalse();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void FillMapEventPositiveResultTest()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg1 = new Cargo(0, 5, 5);
            Point start = new Point(0, 0);
            Point expected = new Point(4, 4); 
            sv.SupervisorEvent += Supervisor_SupervisorEvent;

            // Act
            sv.FillMap(start, crg1);

            bool exp = helper.CheckTrue();

            // Assert
            Assert.True(exp);
        }

        [Fact]
        public void FillMapEventNegativeResultTest()
        {
            // Arrange
            Container cnt = new Container(4, 4);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg1 = new Cargo(0, 5, 5);
            Point start = new Point(0, 0);
            sv.SupervisorEvent += Supervisor_SupervisorEvent;

            // Act
            sv.FillMap(start, crg1);

            bool expected = helper.CheckFalse();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void EraseCargoFromMapEventPositiveResultTest()
        {
            // Arrange
            Container cnt = new Container(6, 6);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg1 = new Cargo(0, 5, 5);
            sv.SupervisorEvent += Supervisor_SupervisorEvent;

            // Act
            var coor = sv.FindPlaceAndLoadOnIt(crg1);
            sv.LoadList.Add(crg1.Id, coor);
            sv.EraseCargoFromMap(crg1);

            bool expected = helper.CheckTrue();

            // Assert
            Assert.True(expected);
        }

        [Fact]
        public void EraseCargoFromMapEventNegativeResultTest()
        {
            // Arrange
            Container cnt = new Container(6, 6);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg1 = new Cargo(0, 5, 5);
            sv.SupervisorEvent += Supervisor_SupervisorEvent;

            // Act
            sv.EraseCargoFromMap(crg1);
            bool expected = helper.CheckFalse();

            // Assert
            Assert.True(expected);
        }

        private void Supervisor_SupervisorEvent(object sender, SupervisorEventArgs e)
        {
            helper.EventRouting(e);
        }
    }
}
