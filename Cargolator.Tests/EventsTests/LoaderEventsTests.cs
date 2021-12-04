using Cargolator.API.Base;
using Cargolator.API.Base.Enums;
using Cargolator.API.Base.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests.EventsTests
{
    public class LoaderEventsTests
    {

        EventTestHelper helper = new EventTestHelper();
        
        [Fact]
        public void LoadEventTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            ldr.LoadCargoEvent += Loader_LoadCargoEvent;

            // Act
            ldr.Take(crg);
            ldr.Load(cnt);

            bool expected = helper.CheckTrue();

            Assert.True(expected);
        }

        [Fact]
        public void TryLoadLoadEventPositiveResultTest()
        {
            // Arrange
            Container cnt = new Container(5, 5);
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            ldr.LoadCargoEvent += Loader_LoadCargoEvent;

            // Act
            helper.ClearMessages();

            ldr.Take(crg);

            ldr.TryLoad(cnt);

            bool expected = helper.CheckTrue();

            Assert.True(expected);
        }

        [Fact]
        public void TryLoadEventNegativeResultTest()
        {
            // Arrange
            Container cnt = null;
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            ldr.LoadCargoEvent += Loader_LoadCargoEvent;

            // Act
            ldr.Take(crg);

            ldr.TryLoad(cnt);

            bool expected = helper.CheckFalse();

            Assert.True(expected);
        }

        [Fact]
        public void RotateEventTest()
        {
            // Arrange
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 2, 1);
            ldr.RotateCargoEvent += Loader_RotateCargoEvent;

            // Act
            helper.ClearMessages();
            ldr.Take(crg);
            ldr.Rotate();

            bool expected = helper.CheckTrue();

            Assert.True(expected);
        }

        [Fact]
        public void TryRotateEventPositiveResultTest()
        {
            // Arrange
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 2, 1);
            ldr.RotateCargoEvent += Loader_RotateCargoEvent;

            // Act
            helper.ClearMessages();
            ldr.Take(crg);

            ldr.TryRotate();

            bool expected = helper.CheckTrue();

            Assert.True(expected);
        }

        [Fact]
        public void TryRotateTakedCargoIsNullEventNegativeResultTest()
        {
            // Arrange
            Loader ldr = new Loader();
            ldr.RotateCargoEvent += Loader_RotateCargoEvent;

            // Act
            ldr.TryRotate();
            bool expected = helper.CheckFalse();

            Assert.True(expected);
        }

        [Fact]
        public void TryRotateTakedCargoIsSquareEventNegativeResultTest()
        {
            // Arrange
            Loader ldr = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            ldr.RotateCargoEvent += Loader_RotateCargoEvent;

            // Act
            ldr.Take(crg);
            ldr.TryRotate();
            bool expected = helper.CheckFalse();

            Assert.True(expected);
        }

        [Fact]
        public void TakeFromStockEventTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 2, 2);
            Loader ldr = new Loader();
            ldr.TakeFromStockCargoEvent += Loader_TakeFromStockCargoEvent;

            // Act
            stck.AddCargo(crg);
            ldr.TakeFromStock(stck);

            bool expected = helper.CheckTrue();

            Assert.True(expected);
        }

        [Fact]
        public void TryTakeFromStockEventPositiveResultTest()
        {
            // Arrange
            Stock stck = new Stock();
            Cargo crg = new Cargo(0, 2, 2);
            Loader ldr = new Loader();
            ldr.TakeFromStockCargoEvent += Loader_TakeFromStockCargoEvent;

            // Act
            stck.AddCargo(crg);

            ldr.TryTakeFromStock(stck);

            bool expected = helper.CheckTrue();

            Assert.True(expected);
        }

        [Fact]
        public void TryTakeFromStockEventNegativeResultTest()
        {
            // Arrange
            Stock stck = new Stock();
            Loader ldr = new Loader();
            ldr.TakeFromStockCargoEvent += Loader_TakeFromStockCargoEvent;

            // Act
            ldr.TryTakeFromStock(stck);

            bool expected = helper.CheckFalse();

            Assert.True(expected);
        }


        private void Loader_LoadCargoEvent(object sender, WorkerEventArgs e)
        {
            helper.EventRouting(e);
        }
        private void Loader_RotateCargoEvent(object sender, WorkerEventArgs e)
        {
            helper.EventRouting(e);
        }
        private void Loader_TakeFromStockCargoEvent(object sender, WorkerEventArgs e)
        {
            helper.EventRouting(e);
        }
    }
}
