namespace HexagonalArchitecture.Domain
{
    public interface IContainerService
    {
        T Resolve<T>();
    }
}
