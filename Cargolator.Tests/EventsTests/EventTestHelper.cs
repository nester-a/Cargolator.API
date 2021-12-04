using Cargolator.API.Base.AbstractClasses;
using System.Collections.Generic;

namespace Cargolator.Tests.EventsTests
{
    internal class EventTestHelper
    {
        internal bool testTrue { get; private set; } = false;
        internal bool testFalse { get; private set; } = false;
        internal string lastMes { get; private set; } = null;
        internal List<string> messages { get; private set; } = new List<string>();

        internal void Reset()
        {
            testTrue = false;
            testFalse = false;
            lastMes = null;
        }
        internal bool CheckFalse()
        {
            if (testFalse && lastMes is not null) return true;
            return false;
        }
        internal bool CheckTrue()
        {
            if (testTrue && lastMes is not null) return true;
            return false;
        }
        internal void EventRouting(BaseEventArgs e)
        {
            Reset();
            if (e.EventResult == true)
            {
                testTrue = true;
                lastMes = e.Message;
                messages.Add(lastMes);
            }
            if (e.EventResult == false)
            {
                testFalse = true;
                lastMes = e.Message;
                messages.Add(lastMes);
            }
        }

        internal void ClearMessages()
        {
            messages.Clear();
        }
    }
}
