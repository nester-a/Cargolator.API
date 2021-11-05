using Cargolator.Domain.Base;
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
            Container cnt = new Container() { Length = 10, Width = 10 };
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo() { Length = 4, Width = 2 };

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
            Container cnt = new Container() { Length = 10, Width = 10 };
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo() { Length = 4, Width = 2 };

            // Act
            sv.LoadList.Add(crg.Id, sv.FindLoadPlace(crg));
            bool result = sv.EraceCargoFromMap(crg);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckSquareTest()
        {
            // Arrange
            Container cnt = new Container() { Length = 10, Width = 10 };
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo() { Length = 4, Width = 2 };
            Cargo crg2 = new Cargo() { Length = 2, Width = 2 };

            // Act
            sv.LoadList.Add(crg.Id, sv.FindLoadPlace(crg));
            var result = sv.CheckSquare(new Point(1, 2), crg2);

            // Assert
            Assert.True(!result);
        }

        [Fact]
        public void FillMapTest()
        {
            // Arrange
            Container cnt = new Container() { Length = 10, Width = 10 };
            Supervisor sv = new Supervisor(cnt);
            Cargo crg = new Cargo() { Length = 4, Width = 2, Id = 1 };
            Cargo crg2 = new Cargo() { Length = 2, Width = 4, Id = 2 };

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
            Container cnt = new Container() { Length = 10, Width = 10 };
            Supervisor sv = new Supervisor(cnt);
            List<Cargo> crgs = new List<Cargo>()
            {
                new Cargo() { Length = 3, Width = 3, Id = 1 },
                new Cargo() { Length = 2, Width = 4, Id = 2 },
                new Cargo() { Length = 3, Width = 3, Id = 3 },
                new Cargo() { Length = 5, Width = 6, Id = 4 },
                new Cargo() { Length = 1, Width = 4, Id = 5 },
                new Cargo() { Length = 2, Width = 2, Id = 6 },
                new Cargo() { Length = 2, Width = 2, Id = 7 },
                new Cargo() { Length = 2, Width = 2, Id = 8 },
                new Cargo() { Length = 2, Width = 2, Id = 9 },

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
