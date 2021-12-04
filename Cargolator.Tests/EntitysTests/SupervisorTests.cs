using Cargolator.API.Base;
using Xunit;

namespace Cargolator.Tests.EntitysTests
{
    public class SupervisorTests
    {
        [Fact]
        public void FindLoadPlaceNotNullTest()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo(0, 5, 5);

            // Act
            var result = sv.FindPlaceAndLoadOnIt(crg);
            Coordinates exp = new Coordinates(new Point(0, 0), new Point(4, 4));

            // Assert
            Assert.Equal<Coordinates>(exp, result);
        }

        [Fact]
        public void FindLoadPlaceNullTest()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg1 = new Cargo(0, 10, 10);
            Cargo crg2 = new Cargo(0, 10, 10);

            // Act
            sv.FindPlaceAndLoadOnIt(crg1);
            var result = sv.FindPlaceAndLoadOnIt(crg2);

            // Assert
            Assert.True(result is null);
        }

        [Fact]
        public void CheckSquareTrueTest()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo(0, 5, 5);
            Point p = new Point(0, 0);

            // Act
            var result = sv.CheckSquare(p, crg);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckSquareFalseTest()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg1 = new Cargo(0, 5, 5);
            Cargo crg2 = new Cargo(1, 3, 5);
            Point p = new Point(0, 0);

            // Act
            sv.FindPlaceAndLoadOnIt(crg1);
            var result = sv.CheckSquare(p, crg2);

            // Assert
            Assert.True(!result);
        }

        [Fact]
        public void FillMapNotNullTest()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg1 = new Cargo(0, 5, 5);
            Point start = new Point(0, 0);
            Point expected = new Point(4, 4);

            // Act
            var result = sv.FillMap(start, crg1);

            // Assert
            Assert.Equal<Point>(expected, result);
        }

        [Fact]
        public void FillMapNullTest()
        {
            // Arrange
            Container cnt = new Container(4, 4);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg1 = new Cargo(0, 5, 5);
            Point start = new Point(0, 0);

            // Act
            var end = sv.FillMap(start, crg1);

            bool result = end is null;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void EraseCargoFromMapTrueTest()
        {
            // Arrange
            Container cnt = new Container(6, 6);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg1 = new Cargo(0, 5, 5);

            // Act
            var coor = sv.FindPlaceAndLoadOnIt(crg1);
            sv.LoadList.Add(crg1.Id, coor);
            var result = sv.EraseCargoFromMap(crg1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void EraseCargoFromMapFalse()
        {
            // Arrange
            Container cnt = new Container(6, 6);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg1 = new Cargo(0, 5, 5);

            // Act
            var result = sv.EraseCargoFromMap(crg1);

            // Assert
            Assert.True(!result);
        }
    }
}
