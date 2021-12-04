using Cargolator.API.Base.AbstractClasses;

namespace Cargolator.API.Base.EventArgs
{
    public class ContainerEventArgs : BaseEventArgs
    {
        public ContainerEventArgs(string message, bool eventResult) : base(message, eventResult) { }
    }
}
