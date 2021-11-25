using Cargolator.API.Base;
using Cargolator.API.Base.AbstractClasses;
using Cargolator.API.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests
{
    public class WorkerExceptionsTests
    {
        [Fact]
        public void TakeCargoArgumentNullExceptionTest()
        {
            Worker wrk = new Loader();
            Cargo crg = null;

            bool catched = false;

            try
            {
                wrk.Take(crg);
            }
            catch (ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }

        [Fact]
        public void TakeCargoTakedCargoIsNotNullInvalidOperationExceptionTest()
        {
            Worker wrk = new Loader();
            Cargo crg1 = new Cargo(0,1,1);
            Cargo crg2 = new Cargo(1,1,1);

            bool catched = false;

            wrk.Take(crg1);
            try
            {
                wrk.Take(crg2);
            }
            catch (InvalidOperationException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }

        [Fact]
        public void DropCargoTakedCargoIsNullNullReferenceExceptionTest()
        {
            Worker wrk = new Loader();

            bool catched = false;

            try
            {
                wrk.DropCargo();
            }
            catch (NullReferenceException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }

        [Fact]
        public void DropCargoOverrideTakedCargoIsNullNullReferenceExceptionTest()
        {
            Worker wrk = new Loader();

            bool catched = false;

            try
            {
                wrk.DropCargo(CargoStatus.OnStock);
            }
            catch (NullReferenceException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }

        [Fact]
        public void DropCargoOverrideDropedCargoStatusArgumentExceptionTest()
        {
            Worker wrk = new Loader();
            Cargo crg = new Cargo(0, 1, 1);

            bool catched = false;

            wrk.Take(crg);
            try
            {
                wrk.DropCargo(CargoStatus.OnHands);
            }
            catch (ArgumentException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }

        [Fact]
        public void TakeFromWorkerWorkerArgumentNullExceptionTest()
        {
            Worker wrk1 = new Loader();
            Worker wrk2 = null;

            bool catched = false;

            try
            {
                wrk1.TakeFromWorker(wrk2);
            }
            catch(ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }

        [Fact]
        public void TakeFromWorkerWorkerIsThisInvalidOperationExceptionTest()
        {
            Worker wrk1 = new Loader();

            bool catched = false;

            try
            {
                wrk1.TakeFromWorker(wrk1);
            }
            catch (InvalidOperationException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }

        [Fact]
        public void TakeFromWorkerWorkerTakedCargoIsNullNullReferenceExceptionTest()
        {
            Worker wrk1 = new Loader();
            Worker wrk2 = new Loader();

            bool catched = false;

            try
            {
                wrk1.TakeFromWorker(wrk2);
            }
            catch (NullReferenceException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }

        [Fact]
        public void TakeFromWorkerTakedCargoIsNotNullInvalidOperationExceptionTest()
        {
            Worker wrk1 = new Loader();
            Worker wrk2 = new Loader();
            Cargo crg1 = new Cargo(0, 1, 1);
            Cargo crg2 = new Cargo(1, 1, 1);

            bool catched = false;

            wrk1.Take(crg1);
            wrk2.Take(crg2);

            try
            {
                wrk1.TakeFromWorker(wrk2);
            }
            catch (InvalidOperationException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }
    }
}
