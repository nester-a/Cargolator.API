namespace Cargolator.API.Base.Interfaces
{
    public interface ITakeCargo
    {
        Cargo TakedCargo { get; }
        void Take(Cargo cargo);
        bool TryTake(Cargo cargo);
    }
}
