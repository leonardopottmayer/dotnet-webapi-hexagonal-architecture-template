using HexagonalArchitecture.Domain.Adapters.SystemInfoProvider;
using HexagonalArchitecture.Domain.Entities;

namespace HexagonalArchitecture.Adapter.SystemInfoProvider.Models
{
    public class SystemMessageReferenceData : ISystemMessageReferenceData
    {
        public IEnumerable<SystemMessage> Items { get; private set; }

        public SystemMessageReferenceData(IEnumerable<SystemMessage> items)
        {
            Items = items;
        }
    }
}
