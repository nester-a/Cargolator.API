namespace Cargolator.API.Base.Interfaces
{
    public interface IUnloader : ITakeCargo
    {
        void Unload(ILoadable container);
        bool TryUnload(ILoadable container);

    }
}
