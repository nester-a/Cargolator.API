namespace Cargolator.API.Base.Interfaces
{
    public interface ILoader : ITakeCargo
    {
        void Load(ILoadable container);
        bool TryLoad(ILoadable container);
        void Rotate();
        void TakeFromStock(IStock stock);
        bool TryTakeFromStock(IStock stock);
    }
}
