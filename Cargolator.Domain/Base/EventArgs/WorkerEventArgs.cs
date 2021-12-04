using Cargolator.API.Base.AbstractClasses;

namespace Cargolator.API.Base.EventArgs
{
    public class WorkerEventArgs : BaseEventArgs
    {
        public WorkerEventArgs(string message, bool eventResult) : base (message, eventResult){ }
    }
}
