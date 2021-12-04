using Cargolator.API.Base;
using System;
using Xunit;

namespace Cargolator.Tests.ExceptionsTests
{
    public class SupervisorExceptionsTests
    {
        [Fact]
        public void SupervisorConstructorContainerArgumentNullExceptionTest()
        {
            // Arrange
            Container cnt = null;

            bool catched = false;

            // Act
            try
            {
                Supervisor sv = new Supervisor(cnt);
            }
            catch(ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }

        [Fact]
        public void FindPlaceAndLoadOnItCargoArgumentNullExceptionTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = null;

            bool catched = false;

            // Act
            try
            {
                sv.FindPlaceAndLoadOnIt(crg);
            }
            catch(ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }

        [Fact]
        public void CheckSquareStartPointArgumentNullExceptionTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo(0, 1, 1);
            Point p = null;

            bool catched = false;

            // Act
            try
            {
                sv.CheckSquare(p, crg);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }

        [Fact]
        public void CheckSquareCargoArgumentNullExceptionTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = null;
            Point p = new Point(1, 1);

            bool catched = false;

            // Act
            try
            {
                sv.CheckSquare(p, crg);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }

        [Fact]
        public void FillMaStartPointArgumentNullExceptionTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo(0, 1, 1);
            Point p = null;

            bool catched = false;

            // Act
            try
            {
                sv.FillMap(p, crg);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }

        [Fact]
        public void FillMapCargoArgumentNullExceptionTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = null;
            Point p = new Point(1, 1);

            bool catched = false;

            // Act
            try
            {
                sv.FillMap(p, crg);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }

        [Fact]
        public void EraseCargoFromMapCargoArgumentNullExceptionTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = null;

            bool catched = false;

            // Act
            try
            {
                sv.EraseCargoFromMap(crg);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            // Assert
            Assert.True(catched);
        }
    }
}
