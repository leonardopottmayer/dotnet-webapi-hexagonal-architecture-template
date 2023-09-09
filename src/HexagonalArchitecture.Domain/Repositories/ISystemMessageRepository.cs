using HexagonalArchitecture.Domain.Entities;

namespace HexagonalArchitecture.Domain.Repositories
{
    public interface ISystemMessageRepository : IRepository<SystemMessage>
    {
        /// <summary>
        /// Queries the message by its code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<SystemMessage> GetByCode(long code);
    }
}
