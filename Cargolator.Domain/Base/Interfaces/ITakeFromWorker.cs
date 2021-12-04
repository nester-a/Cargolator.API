namespace Cargolator.API.Base.Interfaces
{
    public interface ITakeFromWorker: IDropCargo, IWorkerWithType
    {
        void TakeFromWorker(ITakeFromWorker otherWorker);
        bool TryTakeFromWorker(ITakeFromWorker otherWorker);
    }
}
