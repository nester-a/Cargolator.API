using Cargolator.API.Base.AbstractClasses;

namespace Cargolator.API.Base.EventArgs
{
    public class StockEventArgs : BaseEventArgs
    {
        public StockEventArgs(string message, bool eventResult) : base(message, eventResult) { }
    }
}
