using Cargolator.API.Base;
using System;
using Xunit;

namespace Cargolator.Tests.ExceptionsTests
{
    public class UnloaderExceptionsTests
    {
        [Fact]
        public void UnloadContainerArgumentNullExceptionTest()
        {
            Unloader unldr = new Unloader();
            Container cnt = null;

            bool catched = false;

            try
            {
                unldr.Unload(cnt);
            }
            catch(ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }

        [Fact]
        public void UnloadContainerIsEmptyInvalidOperationExceptionTest()
        {
            Unloader unldr = new Unloader();
            Container cnt = new Container(5, 5);

            bool catched = false;

            try
            {
                unldr.Unload(cnt);
            }
            catch (InvalidOperationException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }

        [Fact]
        public void UnloadTakedCargoIsNotNullInvalidOperationExceptionTest()
        {
            Unloader unldr = new Unloader();
            Container cnt = new Container(5, 5);
            Cargo crg1 = new Cargo(0, 2, 2);
            Cargo crg2 = new Cargo(1, 2, 2);

            bool catched = false;

            unldr.Take(crg1);
            cnt.AddCargo(crg2);
            try
            {
                unldr.Unload(cnt);
            }
            catch (InvalidOperationException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }

        [Fact]
        public void PlaceToStockStockArgumentNullExceptionTest()
        {
            Unloader unldr = new Unloader();
            Stock stck = null;
            Cargo crg = new Cargo(0, 1, 1);

            bool catched = false;

            unldr.Take(crg);
            try
            {
                unldr.PlaceToStock(stck);
            }
            catch(ArgumentNullException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }

        [Fact]
        public void PlaceToStockTakedCargoIsNullInvalidOperationExceptionTest()
        {
            Unloader unldr = new Unloader();
            Stock stck = new Stock();

            bool catched = false;

            try
            {
                unldr.PlaceToStock(stck);
            }
            catch (InvalidOperationException e)
            {
                if (e is not null) catched = true;
            }

            Assert.True(catched);
        }
    }
}
