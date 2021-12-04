namespace Cargolator.API.Base.Interfaces
{
    public interface ICargo : ISizeable, ICargoStatus
    {
        int Id { get; }
    }
}
