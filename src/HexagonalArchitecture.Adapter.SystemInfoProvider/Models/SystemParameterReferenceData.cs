using HexagonalArchitecture.Domain.Adapters.SystemInfoProvider;
using HexagonalArchitecture.Domain.Entities;

namespace HexagonalArchitecture.Adapter.SystemInfoProvider.Models
{
    public class SystemParameterReferenceData : ISystemParameterReferenceData
    {
        public IEnumerable<SystemParameter> Items { get; private set; }

        public SystemParameterReferenceData(IEnumerable<SystemParameter> items)
        {
            Items = items;
        }
    }
}
