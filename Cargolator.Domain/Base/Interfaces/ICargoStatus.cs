using Cargolator.API.Base.Enums;

namespace Cargolator.API.Base.Interfaces
{
    public interface ICargoStatus
    {
        CargoStatus Status { get; }
        void ChangeStatus(CargoStatus newStatus);
    }
}
