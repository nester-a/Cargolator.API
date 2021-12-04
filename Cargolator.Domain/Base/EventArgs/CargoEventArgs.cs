using Cargolator.API.Base.AbstractClasses;

namespace Cargolator.API.Base.EventArgs
{
    public class CargoEventArgs : BaseEventArgs
    {
        public CargoEventArgs(string message, bool eventResult) : base(message, eventResult) { }
    }
}
