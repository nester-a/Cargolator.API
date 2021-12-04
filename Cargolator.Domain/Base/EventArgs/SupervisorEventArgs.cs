using Cargolator.API.Base.AbstractClasses;

namespace Cargolator.API.Base.EventArgs
{
    public class SupervisorEventArgs : BaseEventArgs
    {
        public SupervisorEventArgs(string message, bool eventResult) : base(message, eventResult) { }
    }
}
