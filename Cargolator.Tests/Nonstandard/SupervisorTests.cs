using Cargolator.API.Base;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cargolator.Tests
{
    public class SupervisorTests
    {
        [Fact]
        public void FindLoadPlaceResult()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo(0, 4, 2);

            // Act
            Coordinates result = sv.FindLoadPlace(crg);
            Coordinates expected = new Coordinates(new Point(0, 0), new Point(1, 3));
            var actual = result.Equals(expected);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void EraseCargoFromMapResult()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo(0, 4, 2);

            // Act
            sv.LoadList.Add(crg.Id, sv.FindPlace(crg));
            bool result = sv.EraceCargoFromMap(crg);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckSquareTest()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo(0, 4, 2);
            Cargo crg2 = new Cargo(1, 2, 2);

            // Act
            sv.LoadList.Add(crg.Id, sv.FindPlace(crg));
            var result = sv.CheckSquare(new Point(1, 1), crg2);

            // Assert
            Assert.True(!result);
        }

        [Fact]
        public void FillMapTest()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo(1, 4, 2);
            Cargo crg2 = new Cargo(2, 2, 4);

            // Act
            sv.LoadList.Add(crg.Id, sv.FindLoadPlace(crg));
            var result = sv.FillMap(new Point(0, 4), crg2);

            // Assert
            // заглушка
            Assert.True(true);
        }

        [Fact]
        public void FindNewPlace()
        {
            // Arrange
            Container cnt = new Container(10, 10);
            Supervisor sv = new Supervisor(cnt);
            List<Cargo> crgs = new List<Cargo>()
            {
                new Cargo(1, 3, 3),
                new Cargo(2, 2, 4),
                new Cargo(3, 3, 3),
                new Cargo(4, 5, 6),
                new Cargo(5, 1, 4),
                new Cargo(6, 2, 2),
                new Cargo(7, 2, 2),
                new Cargo(8, 2, 2),
                new Cargo(9, 2, 2),

            };
            List<bool> results = new List<bool>();

            //Act

            for (int i = 0; i < crgs.Count; i++)
            {
                var coor = sv.FindPlace(crgs[i]);
                if (coor is null) results.Add(false);
                else results.Add(true);
            }


            bool AllAreTrue()
            {
                for (int i = 0; i < results.Count; i++)
                {
                    if (results[i] == false) return false;
                }
                return true;
            }
            //Assert
            Assert.True(AllAreTrue());
        }
    }
}
