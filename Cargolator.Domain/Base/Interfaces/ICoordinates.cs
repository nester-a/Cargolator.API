namespace Cargolator.API.Base.Interfaces
{
    public interface ICoordinates
    {
        IPoint UpperLeftCorner { get; }
        IPoint LowerRightCorner { get; }
    }
}
