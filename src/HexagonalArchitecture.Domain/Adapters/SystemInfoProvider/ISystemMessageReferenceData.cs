using HexagonalArchitecture.Domain.Entities;

namespace HexagonalArchitecture.Domain.Adapters.SystemInfoProvider
{
    public interface ISystemMessageReferenceData
    {
        IEnumerable<SystemMessage> Items { get; }
    }
}
