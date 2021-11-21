using Cargolator.API.Base;
using Cargolator.API.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests
{
    public class EntityCreateTests
    {
        [Fact]
        public void CargoCreateTest()
        {
            // Arrange
            int id = 0;
            int x = 20;
            int y = 20;

            // Act
            Cargo crg = new Cargo(id, y, x);

            bool result = crg is not null && crg.Id == 0 && crg.Length == 20 && crg.Width == 20 && crg.Status == CargoStatus.Wait;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ContainerCreateTest()
        {
            // Arrange
            int length = 12;
            int width = 3;

            // Act
            Container cnt = new Container(length, width);

            bool result = cnt is not null && cnt.Length == 12 && cnt.Width == 3 && cnt.LoadedCargo is not null;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PointCreateTest()
        {
            // Arrange
            int x = 2;
            int y = 3;

            // Act
            Point p = new Point(x, y);

            bool result = p is not null && p.X == 2 && p.Y == 3;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CoordinatesCreateTest()
        {
            // Arrange
            Point startPoint = new Point(0, 0);
            Point finishPoint = new Point(2, 4);

            // Act
            Coordinates coor = new Coordinates(startPoint, finishPoint);

            bool result = coor is not null && coor.UpperLeftCorner is not null && coor.UpperLeftCorner.Equals(startPoint) && coor.LowerRightCorner is not null && coor.LowerRightCorner.Equals(finishPoint);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void LoaderCreateTest()
        {
            // Arrange
            // Act
            Loader ldr = new Loader();

            bool result = ldr is not null && ldr.ThisWorkerType == WorkerType.Loader;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void StockCreateTest()
        {
            // Arrange
            // Act
            Stock stck = new Stock();

            bool result = stck is not null && stck.CargosStock is not null;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void SupervisorCreateTest()
        {
            // Arrange
            Container cnt = new Container(12, 3);

            // Act
            Supervisor sv = new Supervisor(cnt);

            bool result = sv is not null && sv.ContainerMap.GetLength(0) == 12 && sv.ContainerMap.GetLength(1) == 3 && sv.LoadList is not null;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UnloaderCreateTest()
        {
            // Arrange
            // Act
            Unloader unldr = new Unloader();

            bool result = unldr is not null && unldr.ThisWorkerType == WorkerType.Unloader;

            // Assert
            Assert.True(result);
        }
    }
}
