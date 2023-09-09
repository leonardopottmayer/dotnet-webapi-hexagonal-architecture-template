namespace HexagonalArchitecture.Domain.Adapters.SystemInfoProvider
{
    public interface ISystemInfoReference
    {
        ISystemParameterReferenceData SystemParameters { get; }
        ISystemMessageReferenceData SystemMessages { get; }
    }
}
