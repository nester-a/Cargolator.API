namespace Cargolator.API.Base.Interfaces
{
    public interface IEventArgs
    {
        string Message { get; }
        bool EventResult { get; }
    }
}
