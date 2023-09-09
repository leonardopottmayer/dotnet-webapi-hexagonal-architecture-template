using HexagonalArchitecture.Domain.Entities;

namespace HexagonalArchitecture.Domain.Adapters.SystemInfoProvider
{
    public interface ISystemParameterReferenceData
    {
        IEnumerable<SystemParameter> Items { get; }
    }
}
