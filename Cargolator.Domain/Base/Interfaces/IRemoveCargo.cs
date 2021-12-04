namespace Cargolator.API.Base.Interfaces
{
    public interface IRemoveCargo
    {
        Cargo RemoveCargo();
        bool TryRemoveCargo(out Cargo cargo);
    }
}
