using Cargolator.API.Base.Interfaces;

namespace Cargolator.API.Base.AbstractClasses
{
    public abstract class BaseEventArgs : IEventArgs
    {
        public string Message { get; set; }
        public bool EventResult { get; set; }
        public BaseEventArgs(string message, bool eventResult)
        {
            Message = message;
            EventResult = eventResult;
        }
    }
}
