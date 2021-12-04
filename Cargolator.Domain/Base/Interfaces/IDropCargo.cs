namespace Cargolator.API.Base.Interfaces
{
    public interface IDropCargo : ITakeCargo
    {
        void DropCargo();
        bool TryDropCargo();
    }
}
