using Cargolator.API.Base.AbstractClasses;
using Cargolator.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests.EventsTests
{
    public class WorkerEventsTests
    {
        bool testTrue = false;
        bool testFalse = false;
        string mes;

        [Fact]
        public void TakeMethodTakeCargoEventTest()
        {
            // Arrange
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 1, 1);
            wrk.TakeCargoEvent += Worker_TakeCargoEvent;

            // Act
            TestersReset();

            // Assert
        }

        private void Worker_TakeCargoEvent(object sender, API.Base.EventArgs.WorkerEventArgs e)
        {
            if (e.EventResult == true)
            {
                testTrue = true;
                mes = e.Message;
            }
            if(e.EventResult == false)
            {
                testFalse = true;
                mes = e.Message;
            }
        }
        private void TestersReset()
        {
            testTrue = false;
            testFalse = false;
            mes = null;
        }
    }
}
