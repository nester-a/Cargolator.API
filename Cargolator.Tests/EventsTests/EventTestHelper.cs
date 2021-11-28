using Cargolator.API.Base.AbstractClasses;

namespace Cargolator.Tests.EventsTests
{
    internal class EventTestHelper
    {
        internal bool testTrue { get; private set; } = false;
        internal bool testFalse { get; private set; } = false;
        internal string mes { get; private set; } = null;

        internal void Reset()
        {
            testTrue = false;
            testFalse = false;
            mes = null;
        }
        internal bool CheckFalse()
        {
            if (testFalse && mes is not null) return true;
            return false;
        }
        internal bool CheckTrue()
        {
            if (testTrue && mes is not null) return true;
            return false;
        }
        internal void EventRouting(BaseEventArgs e)
        {
            Reset();
            if (e.EventResult == true)
            {
                testTrue = true;
                mes = e.Message;
            }
            if (e.EventResult == false)
            {
                testFalse = true;
                mes = e.Message;
            }
        }
    }
}
