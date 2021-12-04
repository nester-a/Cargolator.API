using Cargolator.API.Base.Enums;

namespace Cargolator.API.Base.Interfaces
{
    public interface IWorkerWithType
    {
        WorkerType ThisWorkerType { get; }
    }
}
